using System;
using System.Web;

namespace UnitTestProject1
{
    public class UploadFileService : IUploadFileService
    {

        public UploadFileService(IUploadFileRepository uploadFileRepository, IFileSystemPathService fileSystemPathService)
        {

        }

        public Result SavePicture(HttpPostedFileBase file, int userId)
        {
            throw new NotImplementedException();
        }
    }
}
