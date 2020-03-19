using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains;
using DTO;
using Infrastructure.Exceptions;
using MockQueryable.Moq;
using Moq;
using NUnit.Framework;
using Repos.Abstract;
using Services.Concrete;

namespace Tests
{
    public class Tests
    {
        private Mock<IUserRepository> _mockUserRepository;
        private Mock<IRoleRepository> _mockRoleRepository;

        [SetUp]
        public void Setup()
        {
            _mockRoleRepository = new Mock<IRoleRepository>();

            var roles = new List<Role>
            {
                new Role {Id = 1, Name = "Админ",},
                new Role {Id = 2, Name = "Редактор",},
            }.AsQueryable().BuildMock();

            _mockRoleRepository.Setup(x => x.All)
                .Returns(roles.Object);

            _mockUserRepository = new Mock<IUserRepository>();
        }

        [Test]
        public async Task CanCreateUser()
        {
            var userDto = new UserDto
            {
                Email = "hello-world@kek.ru",
                Login = "how_are_you",
                Name = "Lalalal",
                Password = "zuzuzuz",
                RolesIds = new List<int> {1, 2}
            };

            var userService = new UserService(_mockUserRepository.Object, _mockRoleRepository.Object);

            var res = await userService.Create(userDto);
            
            _mockUserRepository.Verify(x => x.SaveAsync(It.IsAny<User>()), Times.Once);
            Assert.AreEqual(2, res.Roles.Count());
        }

        [Test]
        public async Task CantCreateWithoutRolesUser()
        {
            var userDto = new UserDto
            {
                Email = "hello-world@kek.ru",
                Login = "how_are_you",
                Name = "Lalalal",
                Password = "zuzuzuz",
                RolesIds = new List<int>() // without roles
            };

            var userService = new UserService(_mockUserRepository.Object, _mockRoleRepository.Object);

            var res = await userService.Create(userDto);
            
            _mockUserRepository.Verify(x => x.SaveAsync(It.IsAny<User>()), Times.Never);
        }
        
        [Test]
        public async Task CantCreateWithWrongRolesSetUser()
        {
            var userDto = new UserDto
            {
                Email = "hello-world@kek.ru",
                Login = "how_are_you",
                Name = "Lalalal",
                Password = "zuzuzuz",
                RolesIds = new List<int>{666, 777, 888} // wrong role's set
            };

            var userService = new UserService(_mockUserRepository.Object, _mockRoleRepository.Object);

            try
            {
                var res = await userService.Create(userDto);
            }
            catch (EntityNotExistsException e)
            {
                // Just pass, it's not important here
            }
            
            _mockUserRepository.Verify(x => x.SaveAsync(It.IsAny<User>()), Times.Never);
        }
    }
}