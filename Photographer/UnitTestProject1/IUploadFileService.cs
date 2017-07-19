using System.Web;

namespace UnitTestProject1
{
    public interface IUploadFileService
    {
        Result SavePicture(HttpPostedFileBase file, int userId);
    }
}
