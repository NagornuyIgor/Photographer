using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web;

namespace UnitTestProject1
{
    [TestClass]
    public class UploadFileServiceTest
    {
        [TestMethod]
        public void SavePicture_SaveNotAPicture_FileIsNotSaveTest()
        {
            // Arrange
            var postedFileMock = new Mock<HttpPostedFileBase>();
            postedFileMock.Setup(x => x.FileName).Returns("not-a-picture.exe");
            postedFileMock.Setup(x => x.SaveAs(It.IsAny<string>()));

            var uploadFileRepositoryMock = new Mock<IUploadFileRepository>();
            uploadFileRepositoryMock.Setup(x => x.SaveFile(It.IsAny<object>()));

            Ioc.Add(uploadFileRepositoryMock.Object);

            var uploadFileService = Ioc.Get<IUploadFileService>();

            // Act
            var result = uploadFileService.SavePicture(postedFileMock.Object, 1);

            // Assert
            Assert.AreEqual(result.Message, "Only picture allowed.");
            uploadFileRepositoryMock.Verify(x => x.SaveFile(It.IsAny<object>()), Times.Never);
            postedFileMock.Verify(x => x.SaveAs(It.IsAny<string>()), Times.Never);
        }

        [TestMethod]
        public void SavePicture_SaveAPictureFile_FileIsSaveTest()
        {
            // Arrange
            var savePath = "testPath";

            var postedPictureFileMock1 = new Mock<HttpPostedFileBase>();
            postedPictureFileMock1.Setup(x => x.FileName).Returns("picture1.jpg");

            var postedPictureFileMock2 = new Mock<HttpPostedFileBase>();
            postedPictureFileMock2.Setup(x => x.FileName).Returns("picture1.png");

            var postedPictureFileMock3 = new Mock<HttpPostedFileBase>();
            postedPictureFileMock3.Setup(x => x.FileName).Returns("picture1.gif");

            var fileSystemPathServiceMock = new Mock<FileSystemPathService>();
            fileSystemPathServiceMock.Setup(x => x.GetImageSavePath()).Returns(savePath);

            var uploadFileRepositoryMock = new Mock<IUploadFileRepository>();
            uploadFileRepositoryMock.Setup(x => x.SaveFile(It.IsAny<object>()));
            uploadFileRepositoryMock.Setup(x => x.DeleteFile(It.IsAny<object>()));

            Ioc.Add(fileSystemPathServiceMock.Object);
            Ioc.Add(uploadFileRepositoryMock.Object);

            var uploadFileService = Ioc.Get<IUploadFileService>();

            // Act
            var result1 = uploadFileService.SavePicture(postedPictureFileMock1.Object, 1);
            var result2 = uploadFileService.SavePicture(postedPictureFileMock2.Object, 1);
            var result3 = uploadFileService.SavePicture(postedPictureFileMock3.Object, 1);

            // Assert
            Assert.AreEqual(result1.Status, "Success");
            postedPictureFileMock1.Verify(x => x.SaveAs(savePath), Times.Once);
            postedPictureFileMock2.Verify(x => x.SaveAs(savePath), Times.Once);
            postedPictureFileMock3.Verify(x => x.SaveAs(savePath), Times.Once);
            fileSystemPathServiceMock.Verify(x => x.GetImageSavePath(), Times.Exactly(3));
            uploadFileRepositoryMock.Verify(x => x.SaveFile(It.IsAny<object>()), Times.Exactly(3));
            uploadFileRepositoryMock.Verify(x => x.DeleteFile(It.IsAny<object>()), Times.Never());
        }

        [TestMethod]
        public void SavePicture_ThrowExceptionWhenSaveFileToFileSystem_DeleteFileCalledTest()
        {
            // Arrange
            var savePath = "testPath";

            var postedPictureFileMock1 = new Mock<HttpPostedFileBase>();
            postedPictureFileMock1.Setup(x => x.FileName).Returns("picture1.jpg");
            postedPictureFileMock1.Setup(x => x.SaveAs(savePath)).Throws(new Exception());

            var fileSystemPathServiceMock = new Mock<FileSystemPathService>();
            fileSystemPathServiceMock.Setup(x => x.GetImageSavePath()).Returns(savePath);

            var uploadFileRepositoryMock = new Mock<IUploadFileRepository>();
            uploadFileRepositoryMock.Setup(x => x.SaveFile(It.IsAny<object>()));
            uploadFileRepositoryMock.Setup(x => x.DeleteFile(It.IsAny<object>()));

            Ioc.Add(fileSystemPathServiceMock.Object);
            Ioc.Add(uploadFileRepositoryMock.Object);

            var uploadFileService = Ioc.Get<IUploadFileService>();

            // Act
            var result1 = uploadFileService.SavePicture(postedPictureFileMock1.Object, 1);

            // Assert
            Assert.AreEqual(result1.Status, "Error");
            postedPictureFileMock1.Verify(x => x.SaveAs(savePath), Times.Once);
            fileSystemPathServiceMock.Verify(x => x.GetImageSavePath(), Times.Once);
            uploadFileRepositoryMock.Verify(x => x.SaveFile(It.IsAny<object>()), Times.Once);
            uploadFileRepositoryMock.Verify(x => x.DeleteFile(It.IsAny<object>()), Times.Once());
        }

    }
}
