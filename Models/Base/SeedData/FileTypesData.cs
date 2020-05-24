using System.Linq;
using apc_bot_api.Constants;
using apc_bot_api.Models.Types;

namespace apc_bot_api.Models.Base.SeedData
{
    public static class FileTypesData
    {
        public static void AddSeedData(AppDbContext _dbContext)
        {
            var idDocType = _dbContext.FileTypes.FirstOrDefault(x => x.Code == FileConstants.Types.IdDoc);
            if (idDocType == null)
            {
                idDocType = new FileType
                    (
                        "удостоверение личности",
                        FileConstants.Types.IdDoc,
                        "id_doc",
                        "фотографии с двух сторон документа удостоверяющий личность"
                    );
                _dbContext.FileTypes.Add(idDocType);
            }

            var GeneralEducCertificateType = _dbContext.FileTypes.FirstOrDefault(x => x.Code == FileConstants.Types.GeneralEducCertificate);
            if (GeneralEducCertificateType == null)
            {
                GeneralEducCertificateType = new FileType
                    (
                        "аттестат",
                        FileConstants.Types.GeneralEducCertificate,
                        "general_education_certificate",
                        "фотография аттестата подтверждающий о получении обще-среднем образовании"
                    );
                _dbContext.FileTypes.Add(GeneralEducCertificateType);
            }
        }
    }
}