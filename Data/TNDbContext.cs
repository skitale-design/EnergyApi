using EnergyApi.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EnergyApi.Data
{
    public class TNDbContext : DbContext
    {
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<SubOrganization> SubOrganizations { get; set; }
        public DbSet<ObjectPotrebleniya> ObjectPotrebleniyas { get; set; }
        public DbSet<TochkaPostavki> PointPostavkis { get; set; }
        public DbSet<TochkaIzmereniya> TochkaIzmereniyas { get; set; }
        public DbSet<RaschetnyPriborUcheta> RaschetnyPriborUchetas { get; set; }
        public DbSet<TransformatorNapryazheniya> TransformatorNapryazheniyas { get; set; }
        public DbSet<TransformatorToka> TransformatorTokas { get; set; }
        public DbSet<Schetchik> Schetchiks { get; set; }

        public TNDbContext(DbContextOptions<TNDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Schetchik schetchik1 = new Schetchik() { TochkaIzmereniyaId = 1, SchetchikId = 1, Number = 1, DatePoverki = DateTime.Parse("11/12/2011"), SchType = "стандартный" };
            Schetchik schetchik2 = new Schetchik() { TochkaIzmereniyaId = 2, SchetchikId = 2, Number = 2, DatePoverki = DateTime.Parse("12/12/2012"), SchType = "стандартный" };
            Schetchik schetchik3 = new Schetchik() { TochkaIzmereniyaId = 3, SchetchikId = 3, Number = 3, DatePoverki = DateTime.Parse("13/12/2013"), SchType = "стандартный" };
            Schetchik schetchik4 = new Schetchik() { TochkaIzmereniyaId = 4, SchetchikId = 4, Number = 4, DatePoverki = DateTime.Parse("18/12/2018"), SchType = "стандартный" };

            TransformatorNapryazheniya transformatorNapryazheniya2 = new TransformatorNapryazheniya() { TochkaIzmereniyaId = 2, TransformatorNapryazheniyaId = 2, Number = 2, DatePoverki = DateTime.Parse("12/12/2012"), KTN = 12, TnType = "" };
            TransformatorNapryazheniya transformatorNapryazheniya1 = new TransformatorNapryazheniya() { TochkaIzmereniyaId = 1, TransformatorNapryazheniyaId = 1, Number = 1, DatePoverki = DateTime.Parse("11/12/2011"), KTN = 11, TnType = "" };
            TransformatorNapryazheniya transformatorNapryazheniya3 = new TransformatorNapryazheniya() { TochkaIzmereniyaId = 3, TransformatorNapryazheniyaId = 3, Number = 3, DatePoverki = DateTime.Parse("13/12/2013"), KTN = 13, TnType = "" };
            TransformatorNapryazheniya transformatorNapryazheniya4 = new TransformatorNapryazheniya() { TochkaIzmereniyaId = 4, TransformatorNapryazheniyaId = 4, Number = 4, DatePoverki = DateTime.Parse("14/12/2014"), KTN = 14, TnType = "" };

            TransformatorToka transformatorToka1 = new TransformatorToka() { TransformatorTokaId = 1, TochkaIzmereniyaId = 1, Number = 11, DatePoverki = DateTime.Parse("11/12/2011"), KTT = 11, TtType = "" };
            TransformatorToka transformatorToka2 = new TransformatorToka() { TransformatorTokaId = 2, TochkaIzmereniyaId = 2, Number = 21, DatePoverki = DateTime.Parse("12/12/2012"), KTT = 21, TtType = "" };
            TransformatorToka transformatorToka3 = new TransformatorToka() { TransformatorTokaId = 3, TochkaIzmereniyaId = 3, Number = 31, DatePoverki = DateTime.Parse("13/12/2013"), KTT = 31, TtType = "" };
            TransformatorToka transformatorToka4 = new TransformatorToka() { TransformatorTokaId = 4, TochkaIzmereniyaId = 4, Number = 41, DatePoverki = DateTime.Parse("14/12/2014"), KTT = 41, TtType = "" };

            TochkaIzmereniya ti1 = new TochkaIzmereniya() { ObjectPotrebleniyaId = 1, TochkaIzmereniyaId = 1, Name = "Точка Измерения 1" };
            TochkaIzmereniya ti2 = new TochkaIzmereniya() { ObjectPotrebleniyaId = 2, TochkaIzmereniyaId = 2, Name = "Точка Измерения 2" };
            TochkaIzmereniya ti3 = new TochkaIzmereniya() { ObjectPotrebleniyaId = 3, TochkaIzmereniyaId = 3, Name = "Точка Измерения 3" };
            TochkaIzmereniya ti4 = new TochkaIzmereniya() { ObjectPotrebleniyaId = 4, TochkaIzmereniyaId = 4, Name = "Точка Измерения 4" };

            TochkaPostavki tp1 = new TochkaPostavki() { MaxPower = 300, TochkaPostavkiId = 1, ObjectPotrebleniyaId = 1 };
            TochkaPostavki tp2 = new TochkaPostavki() { MaxPower = 300, TochkaPostavkiId = 2, ObjectPotrebleniyaId = 2 };
            TochkaPostavki tp3 = new TochkaPostavki() { MaxPower = 300, TochkaPostavkiId = 3, ObjectPotrebleniyaId = 3 };
            TochkaPostavki tp4 = new TochkaPostavki() { MaxPower = 300, TochkaPostavkiId = 4, ObjectPotrebleniyaId = 4 };

            ObjectPotrebleniya op1 = new ObjectPotrebleniya() { SubOrganizationId = 1, ObjectPotrebleniyaId = 1, Name = "Объект потребления 1", Address = "ул. Динамо, дом 1" };
            ObjectPotrebleniya op2 = new ObjectPotrebleniya() { SubOrganizationId = 1, ObjectPotrebleniyaId = 2, Name = "Объект потребления 2", Address = "ул. Динамо, дом 2" };
            ObjectPotrebleniya op3 = new ObjectPotrebleniya() { SubOrganizationId = 2, ObjectPotrebleniyaId = 3, Name = "Объект потребления 3", Address = "ул. Динамо, дом 3" };
            ObjectPotrebleniya op4 = new ObjectPotrebleniya() { SubOrganizationId = 2, ObjectPotrebleniyaId = 4, Name = "Объект потребления 4", Address = "ул. Динамо, дом 4" };

            RaschetnyPriborUcheta rpu1 = new RaschetnyPriborUcheta() { SDate = DateTime.Parse("01/05/2018"), EDate = DateTime.Parse("01/10/2018"), RaschetnyPriborUchetaId = 1, TochkaIzmereniyasId = 1, TochkaPostavkisId = 1 };
            RaschetnyPriborUcheta rpu2 = new RaschetnyPriborUcheta() { SDate = DateTime.Parse("01/05/2016"), EDate = DateTime.Parse("01/05/2017"), RaschetnyPriborUchetaId = 2, TochkaIzmereniyasId = 2, TochkaPostavkisId = 2 };
            RaschetnyPriborUcheta rpu3 = new RaschetnyPriborUcheta() { SDate = DateTime.Parse("01/05/2018"), EDate = DateTime.Parse(""), RaschetnyPriborUchetaId = 3, TochkaIzmereniyasId = 3, TochkaPostavkisId = 3 };
            RaschetnyPriborUcheta rpu4 = new RaschetnyPriborUcheta() { SDate = DateTime.Parse("01/07/2015"), EDate = DateTime.Parse("01/05/2023"), RaschetnyPriborUchetaId = 4, TochkaIzmereniyasId = 4, TochkaPostavkisId = 4 };


            SubOrganization so2 = new SubOrganization()
            {
                SubOrganizationId = 2,
                Name = "ОАО ЭлектроКопыта",
                Address = "пос. Заветы Ильича, ул. Советская, дом 14",
                OrganizationId = 1
            };
            SubOrganization so1 = new SubOrganization()
            {
                SubOrganizationId = 1,
                Name = "ООО ЭлектроРога",
                Address = "пос. Заветы Ильича, проспект Электрификации, дом 2",
                OrganizationId = 1
            };
            Organization organization = new Organization()
            {
                OrganizationId = 1,
                Name = "ЗАО Электроовцы",
                Address = "г. Электроугли, Электродный проезд, дом 1",
            };

            modelBuilder.Entity<Organization>().HasData(organization);

            modelBuilder.Entity<SubOrganization>().HasData(so1);
            modelBuilder.Entity<SubOrganization>().HasData(so2);

            modelBuilder.Entity<ObjectPotrebleniya>().HasData(op1);
            modelBuilder.Entity<ObjectPotrebleniya>().HasData(op2);
            modelBuilder.Entity<ObjectPotrebleniya>().HasData(op3);
            modelBuilder.Entity<ObjectPotrebleniya>().HasData(op4);

            modelBuilder.Entity<TochkaIzmereniya>().HasData(ti1);
            modelBuilder.Entity<TochkaIzmereniya>().HasData(ti2);
            modelBuilder.Entity<TochkaIzmereniya>().HasData(ti3);
            modelBuilder.Entity<TochkaIzmereniya>().HasData(ti4);

            modelBuilder.Entity<TochkaPostavki>().HasData(tp1);
            modelBuilder.Entity<TochkaPostavki>().HasData(tp2);
            modelBuilder.Entity<TochkaPostavki>().HasData(tp3);
            modelBuilder.Entity<TochkaPostavki>().HasData(tp4);

            modelBuilder.Entity<TransformatorToka>().HasData(transformatorToka1);
            modelBuilder.Entity<TransformatorToka>().HasData(transformatorToka2);
            modelBuilder.Entity<TransformatorToka>().HasData(transformatorToka3);
            modelBuilder.Entity<TransformatorToka>().HasData(transformatorToka4);

            modelBuilder.Entity<TransformatorNapryazheniya>().HasData(transformatorNapryazheniya1);
            modelBuilder.Entity<TransformatorNapryazheniya>().HasData(transformatorNapryazheniya2);
            modelBuilder.Entity<TransformatorNapryazheniya>().HasData(transformatorNapryazheniya3);
            modelBuilder.Entity<TransformatorNapryazheniya>().HasData(transformatorNapryazheniya4);

            modelBuilder.Entity<Schetchik>().HasData(schetchik1);
            modelBuilder.Entity<Schetchik>().HasData(schetchik2);
            modelBuilder.Entity<Schetchik>().HasData(schetchik3);
            modelBuilder.Entity<Schetchik>().HasData(schetchik4);


            modelBuilder.Entity<RaschetnyPriborUcheta>().HasData(rpu1);
            modelBuilder.Entity<RaschetnyPriborUcheta>().HasData(rpu2);
            modelBuilder.Entity<RaschetnyPriborUcheta>().HasData(rpu3);
            modelBuilder.Entity<RaschetnyPriborUcheta>().HasData(rpu4);



        }
    }
}
