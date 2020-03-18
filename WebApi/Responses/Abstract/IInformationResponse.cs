namespace WebApi.Responses.Abstract
{
    /// <summary>
    /// Задает формат http ответа. Используется на случай, если нужно сообщить что то типа
    /// status = success, description = all is ok.
    /// </summary>
    public interface IInformationResponse
    {
        string Status { get; set; }
        string Description { get; set; }
    }
}