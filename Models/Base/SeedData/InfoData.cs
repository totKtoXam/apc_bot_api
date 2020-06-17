using System.Collections.Generic;
using System.Linq;
using apc_bot_api.Constants;
using apc_bot_api.Models.Content;

namespace apc_bot_api.Models.Base.SeedData
{
    public static class InfoData
    {
        public static void AddSeedData(AppDbContext _dbContext)
        {
            // var specsCommand = _dbContext.Commands.FirstOrDefault(x => x.Code == CommandConstants.Commands.Specs);

            // var specsInfoType = _dbContext.InfoTypes.FirstOrDefault(x => x.Code == InfoConstants.Types.Specialities);

            #region Specialities
            var specialityList = GetSpecialityList(_dbContext);
            _dbContext.Specialities.AddRange(specialityList);
            #endregion

            _dbContext.SaveChanges();
        }

        public static List<Speciality> GetSpecialityList(AppDbContext _dbContext)
        {
            List<Speciality> specialityList = new List<Speciality>();

            var software = _dbContext.Specialities.FirstOrDefault(x => x.Short == "ВТиПО");
            if (software == null)
            {
                software = new Speciality()
                {
                    Short = "ВТиПО",
                    SpecialtyNum = "1304000",
                    SpecialtyName = "«Вычислительная техника и программное обеспечение»",
                    Price = "195 000 ₸ / год",
                    ClassificName = "1304043 «Техник-программист»",
                    Languages = "казахский язык, русский язык",
                    StudyType = "очная, заочная",
                    StudyPeriod = "на базе 9 классов – 3 года 6 месяцев, на базе 11 класов 2 года 10 месяцев",
                    Exam = "информатика, математика"
                };
                specialityList.Add(software);
            }

            var infoSys = _dbContext.Specialities.FirstOrDefault(x => x.Short == "ИС");
            if (infoSys == null)
            {
                infoSys = new Speciality()
                {
                    Short = "ИС",
                    SpecialtyNum = "1305000",
                    SpecialtyName = "«Информационные системы (по областям применения)»",
                    Price = "195 000 ₸ / год",
                    ClassificName = "1305011 — Дизайнер\n1305023 — Техник-программист",
                    Languages = "казахский язык, русский язык",
                    StudyType = "очная, заочная",
                    StudyPeriod = "на базе 9 классов – 3 года 6 месяцев, на базе 11 класов 2 года 10 месяцев",
                    Exam = "информатика, математика"
                };
                specialityList.Add(infoSys);
            }

            var techService = _dbContext.Specialities.FirstOrDefault(x => x.Short == "ТО");
            if (techService == null)
            {
                techService = new Speciality()
                {
                    Short = "ТО",
                    SpecialtyNum = "",
                    SpecialtyName = "«Техническое обслуживание, ремонт и эксплуатация автотранспортных средств»",
                    Price = "195 000 ₸ / год",
                    ClassificName = "1201123 техник-механик\n120107 2 слесарь по ремонту автомобилей\n120109 2 мастер по ремонту транспорта\n120113 3 мехатроник",
                    Languages = "казахский язык, русский язык",
                    StudyType = "очная, заочная",
                    StudyPeriod = "на базе 9 классов – 3 года 6 месяцев, на базе 11 класов 2 года 10 месяцев"
                };
                specialityList.Add(techService);
            }

            var hostelServ = _dbContext.Specialities.FirstOrDefault(x => x.Short == "ОГХ");
            if (hostelServ == null)
            {
                hostelServ = new Speciality()
                {
                    Short = "ОГХ",
                    SpecialtyNum = "",
                    SpecialtyName = "«Организация обслуживания гостиничных хозяйств»",
                    Price = "195 000 ₸ / год",
                    ClassificName = "0507063 «менеджер по сервису»",
                    Languages = "казахский язык, русский язык",
                    StudyType = "очная",
                    StudyPeriod = "на базе 9 классов 2 года 10 месяцев",
                    Exam = "каз/рус язык"
                };
                specialityList.Add(hostelServ);
            }

            var builder = _dbContext.Specialities.FirstOrDefault(x => x.Short == "СиЭЗиС");
            if (builder == null)
            {
                builder = new Speciality()
                {
                    Short = "СиЭЗиС",
                    SpecialtyNum = "",
                    SpecialtyName = "«Строительство и эксплуатация зданий и сооружений»",
                    Price = "195 000 ₸ / год",
                    ClassificName = "«техник-строитель»\nквалификация «мастер отделочных строительных работ»",
                    Languages = "казахский язык, русский язык",
                    StudyType = "",
                    StudyPeriod = "2 года 10 месяцев"
                };
                specialityList.Add(builder);
            }

            var gazSys = _dbContext.Specialities.FirstOrDefault(x => x.Short == "МиЭОиСГ");
            if (gazSys == null)
            {
                gazSys = new Speciality()
                {
                    Short = "МиЭОиСГ",
                    SpecialtyNum = "",
                    SpecialtyName = "«Монтаж и эксплуатация оборудования и систем газоснабжения»",
                    Price = "195 000 ₸ / год",
                    ClassificName = "140501 2 – Слесарь по эксплуатации и ремонту газового оборудования\n140502 2 – Слесарь аварийно-восстановительных работ в газовом хозяйстве\n140504 3 – Техник по эксплуатации оборудования газовых объектов\n1405012 «Cлесарь по эксплуатации и ремонту газового оборудования»\n1405022 «Cлесарь аварийно-восстановительных работ в газовом хозяйстве»\n140504 3 «Техник по эксплуатации оборудования газовых объектов»",
                    Languages = "русский язык",
                    StudyType = "очная",
                    StudyPeriod = "Нормативный срок обучения 3 года 10 месяцев на базе основного среднего образования"
                };
                specialityList.Add(gazSys);
            }

            var uchetAndAudit = _dbContext.Specialities.FirstOrDefault(x => x.Short == "УА");
            if (uchetAndAudit == null)
            {
                uchetAndAudit = new Speciality()
                {
                    Short = "УА",
                    SpecialtyNum = "0518000",
                    SpecialtyName = "«Учет и аудит»",
                    Price = "195 000 ₸ / год",
                    ClassificName = "0518033 Экономист-бухгалтер",
                    Languages = "казахский язык, русский язык",
                    StudyType = "очная",
                    StudyPeriod = "на базе 9 классов 2 года 10 месяцев",
                    Exam = "математика, каз/рус язык"
                };
                specialityList.Add(uchetAndAudit);
            }

            var tourist = _dbContext.Specialities.FirstOrDefault(x => x.Short == "ОТ");
            if (tourist == null)
            {
                tourist = new Speciality()
                {
                    Short = "ОТ",
                    SpecialtyNum = "",
                    SpecialtyName = "«Туризм»",
                    Price = "195 000 ₸ / год",
                    ClassificName = "0511043 «менеджер»",
                    Languages = "казахский язык, русский язык",
                    StudyType = "очная",
                    StudyPeriod = "на базе 9 классов — 3 года 10 месяцев",
                    Exam = "география, математика, каз/рус язык"
                };
                specialityList.Add(tourist);
            }

            var designer = _dbContext.Specialities.FirstOrDefault(x => x.Short == "ДИ");
            if (designer == null)
            {
                designer = new Speciality()
                {
                    Short = "ДИ",
                    SpecialtyNum = "",
                    SpecialtyName = "«Дизайн интерьера, реставрация и реконструкция гражданских зданий»",
                    Price = "195 000 ₸ / год",
                    ClassificName = "«техник-дизайнер»",
                    Languages = "казахский язык, русский язык",
                    StudyType = "",
                    StudyPeriod = "на базе 9 классов – 3 года 10 месяцев",
                    Exam = "творческий экзамен, математика, каз/рус язык"
                };
                specialityList.Add(designer);
            }

            return specialityList;
        }
    }
}