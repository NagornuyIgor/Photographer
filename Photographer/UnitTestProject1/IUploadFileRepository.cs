namespace UnitTestProject1
{
    public interface IUploadFileRepository
    {
        object SaveFile(object file);
        object DeleteFile(object file);
    }
}
