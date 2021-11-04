using System;
using System.Collections.Generic;
using System.Net.Mime;
using Data_Access_Layer.Model;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer
{
    public class AppDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public DbSet<GenreMovie> GenreMovies { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().Property(p => p.Name).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Movie>().Property(p => p.Title).IsRequired().HasMaxLength(125);

            var genres = new List<string>()
            {
                "Фантастика", "Боевик", "Триллер",
                "Приключения", "Биография", "История",
                "Драма", "Военный", "Комедия",
                "Фэнтези", "Криминал", "Детектив",
            };

            for (var i = 1; i <= genres.Count; i++)
            {
                modelBuilder.Entity<Genre>().HasData(new Genre()
                {
                    Id = i,
                    Name = genres[i - 1],
                });
            }

            modelBuilder.Entity<Movie>().HasData(
                new Movie()
                {
                    Id = 1,
                    Title = "Веном 2",
                    CreateYear = new DateTime(2021, 1, 1).ToString("yyyy"),
                    Description = "Более чем через год после тех событий журналист Эдди Брок пытается приспособиться к жизни в качестве хозяина инопланетного симбиота Венома," +
                                  " который наделяет его сверхчеловеческими способностями. Брок пытается возродить свою карьеру и берет интервью у серийного убийцы Клетуса Касади," +
                                  " который по воле случая становится хозяином Карнажа и сбегает из тюрьмы после неудавшейся казни.",
                    Image = "https://res.cloudinary.com/pa2/image/upload/v1636022558/Venom_2_wg6ejn.jpg"
                },
                new Movie()
                {
                    Id = 2,
                    Title = "Последняя дуэль",
                    CreateYear = new DateTime(2021, 1, 1).ToString("yyyy"),
                    Description = "Нормандский рыцарь Жан де Карруж по возвращении с войны узнаёт, что его сосед и соперник Жак Ле Гри изнасиловал " +
                                  "его жену Маргарит. Однако у Ле Гри обнаружились сильные союзники, словам женщины никто не верит, и Карруж обращается" +
                                  " за помощью лично к королю Франции Карлу VI. Заслушав все свидетельства, король постановил, что конфликт должен быть " +
                                  "разрешён в честном поединке. От исхода битвы зависит судьба не только Ле Гри и Карружа, но и жены последнего. " +
                                  "В случае поражения мужа её должны сжечь на костре за ложные обвинения.",
                    Image = "https://res.cloudinary.com/pa2/image/upload/v1636022557/Last_duel_e5rsyn.jpg"
                },
                new Movie()
                {
                    Id = 3,
                    Title = "Дракулов",
                    CreateYear = new DateTime(2021, 1, 1).ToString("yyyy"),
                    Description = "Российская империя. Юрист Петр Смирнов приезжает в мрачное имение загадочного графа Дракулова," +
                                  " чьи предки родом из далекой Трансильвании, чтобы оформить покупку дома в Москве. Граф замечает" +
                                  " фотокарточку невесты Петра, юной Вари, и немедленно срывается проинспектировать свою новую " +
                                  "недвижимость… Петр обеспокоен, но его бдительность усыпляют старательные служанки графа. " +
                                  "Правда, вскоре Смирнов обнаруживает, что девушки — вурдалаки, а это значит, что и их хозяин," +
                                  " граф Дракулов, — опасный кровопийца! Петр сбегает из демонической усадьбы и спешит в Москву, " +
                                  "чтобы защитить свою невесту от трехсотлетнего вампира. Помочь ему в этом — или помешать — могут" +
                                  " лучшая подруга Вари, Соня, и ее странные кавалеры, а также сын знаменитого профессора Ван Хельсинга Вася.",
                    Image = "https://res.cloudinary.com/pa2/image/upload/v1636022557/Drakulov_pjwsdp.jpg"
                },
                new Movie()
                {
                    Id = 4,
                    Title = "Учености плоды",
                    CreateYear = new DateTime(2021, 1, 1).ToString("yyyy"),
                    Description = "1944 год. Из Германии в оккупированное немцами село Михайловское в музей Пушкина приезжает профессор литературы" +
                                  " Мария Шиллер и ведет просветительскую работу среди солдат вермахта и местных крестьян, рассказывая им о великом " +
                                  "русском поэте. Ее действия вызывают неодобрение немецкого командования. Фронт приближается всё ближе, и вскоре из " +
                                  "Берлина приходит приказ — вывезти из Михайловского все исторические ценности. Этого никак не могут допустить ни партизаны," +
                                  " ни местный умелец Сергей, которого связывают с Марией недопустимые, губительные для обоих отношения. Сергей решает любой" +
                                  " ценой спасти достояние своей страны. Пушкинское наследие должно остаться в России. Даже ценой жизни…",
                    Image = "https://res.cloudinary.com/pa2/image/upload/v1636022557/Uchenosti_Plody_iq3hkx.jpg"
                },
                new Movie()
                {
                    Id = 5,
                    Title = "Зеленая миля",
                    CreateYear = new DateTime(1999, 1, 1).ToString("yyyy"),
                    Description = "Пол Эджкомб — начальник блока смертников в тюрьме «Холодная гора», каждый из узников" +
                                  " которого однажды проходит «зеленую милю» по пути к месту казни. Пол повидал много заключённых" +
                                  " и надзирателей за время работы. Однако гигант Джон Коффи, обвинённый в страшном преступлении," +
                                  " стал одним из самых необычных обитателей блока.",
                    Image = "https://res.cloudinary.com/pa2/image/upload/v1636022557/Green_MIle_wt2y9b.jpg"
                },
                new Movie()
                {
                    Id = 6,
                    Title = "Побег из Шоушенка",
                    CreateYear = new DateTime(1994, 1, 1).ToString("yyyy"),
                    Description = "Бухгалтер Энди Дюфрейн обвинён в убийстве собственной жены и её любовника. Оказавшись в тюрьме" +
                                  " под названием Шоушенк, он сталкивается с жестокостью и беззаконием, царящими по обе стороны " +
                                  "решётки. Каждый, кто попадает в эти стены, становится их рабом до конца жизни. Но Энди, обладающий" +
                                  " живым умом и доброй душой, находит подход как к заключённым, так и к охранникам, добиваясь их " +
                                  "особого к себе расположения.",
                    Image = "https://res.cloudinary.com/pa2/image/upload/v1636022557/Shawshank_crz3n0.jpg"
                },
                new Movie()
                {
                    Id = 7,
                    Title = "Интерстеллар",
                    CreateYear = new DateTime(2014, 1, 1).ToString("yyyy"),
                    Description = "Когда засуха, пыльные бури и вымирание растений приводят человечество к продовольственному кризису" +
                                  ", коллектив исследователей и учёных отправляется сквозь червоточину (которая предположительно соединяет" +
                                  " области пространства-времени через большое расстояние) в путешествие, чтобы превзойти прежние ограничения" +
                                  " для космических путешествий человека и найти планету с подходящими для человечества условиями.",
                    Image = "https://res.cloudinary.com/pa2/image/upload/v1636022557/Interstellar_utaka5.jpg"
                },
                new Movie()
                {
                    Id = 8,
                    Title = "Криминальное чтиво",
                    CreateYear = new DateTime(1994, 1, 1).ToString("yyyy"),
                    Description = "Двое бандитов Винсент Вега и Джулс Винфилд ведут философские беседы в перерывах между разборками и" +
                                  " решением проблем с должниками криминального босса Марселласа Уоллеса. " +
                                  "В первой истории Винсент проводит незабываемый вечер с женой Марселласа Мией." +
                                  " Во второй рассказывается о боксёре Бутче Кулидже, купленном Уоллесом, чтобы сдать бой." +
                                  " В третьей истории Винсент и Джулс по нелепой случайности попадают в неприятности.",
                    Image = "https://res.cloudinary.com/pa2/image/upload/v1636022557/Pulp_Fiction_pwgblb.jpg"
                },
                new Movie()
                {
                    Id = 9,
                    Title = "Начало",
                    CreateYear = new DateTime(2010, 1, 1).ToString("yyyy"),
                    Description = "Кобб – талантливый вор, лучший из лучших в опасном искусстве извлечения: он крадет " +
                                  "ценные секреты из глубин подсознания во время сна, когда человеческий разум наиболее" +
                                  " уязвим. Редкие способности Кобба сделали его ценным игроком в привычном к предательству" +
                                  " мире промышленного шпионажа, но они же превратили его в извечного беглеца и лишили" +
                                  " всего, что он когда-либо любил. И вот у Кобба появляется шанс исправить ошибки." +
                                  " Его последнее дело может вернуть все назад, но для этого ему нужно совершить невозможное" +
                                  " – инициацию. Вместо идеальной кражи Кобб и его команда спецов должны будут провернуть " +
                                  "обратное. Теперь их задача – не украсть идею, а внедрить ее. Если у них получится, это и" +
                                  " станет идеальным преступлением. Но никакое планирование или мастерство не могут" +
                                  " подготовить команду к встрече с опасным противником, который, кажется, предугадывает каждый" +
                                  " их ход. Врагом, увидеть которого мог бы лишь Кобб.",
                    Image = "https://res.cloudinary.com/pa2/image/upload/v1636022557/Inception_uvkvsd.jpg"
                }
            );

            modelBuilder.Entity<GenreMovie>()
                .HasOne(g => g.Genre)
                .WithMany(gm => gm.GenreMovies)
                .HasForeignKey(gi => gi.GenreId);

            modelBuilder.Entity<GenreMovie>()
                .HasOne(g => g.Movie)
                .WithMany(gm => gm.GenreMovies)
                .HasForeignKey(gi => gi.MovieId);

            modelBuilder.Entity<GenreMovie>().HasData(new List<GenreMovie>()
            {
                new GenreMovie()
                {
                    Id = 1,
                    MovieId = 1,
                    GenreId = 1
                },
                new GenreMovie()
                {
                    Id = 2,
                    MovieId = 1,
                    GenreId = 2
                },
                new GenreMovie()
                {
                    Id = 3,
                    MovieId = 1,
                    GenreId = 3
                },
                new GenreMovie()
                {
                    Id = 4,
                    MovieId = 1,
                    GenreId = 4
                },
                new GenreMovie()
                {
                    Id = 5,
                    MovieId = 2,
                    GenreId = 6
                },
                new GenreMovie()
                {
                    Id = 6,
                    MovieId = 2,
                    GenreId = 7
                },
                new GenreMovie()
                {
                    Id = 7,
                    MovieId = 3,
                    GenreId = 9
                },
                new GenreMovie()
                {
                    Id = 8,
                    MovieId = 4,
                    GenreId = 7
                },
                new GenreMovie()
                {
                    Id = 9,
                    MovieId = 4,
                    GenreId = 8
                },
                new GenreMovie()
                {
                    Id = 10,
                    MovieId = 5,
                    GenreId = 7
                },
                new GenreMovie()
                {
                    Id = 11,
                    MovieId = 5,
                    GenreId = 10
                },
                new GenreMovie()
                {
                    Id = 12,
                    MovieId = 5,
                    GenreId = 11
                },
                new GenreMovie()
                {
                    Id = 13,
                    MovieId = 5,
                    GenreId = 12
                },
                new GenreMovie()
                {
                    Id = 14,
                    MovieId = 6,
                    GenreId = 7
                },
                new GenreMovie()
                {
                    Id = 15,
                    MovieId = 7,
                    GenreId = 1
                },
                new GenreMovie()
                {
                    Id = 16,
                    MovieId = 7,
                    GenreId = 4
                },
                new GenreMovie()
                {
                    Id = 17,
                    MovieId = 7,
                    GenreId = 7
                },
                new GenreMovie()
                {
                    Id = 18,
                    MovieId = 8,
                    GenreId = 7
                },
                new GenreMovie()
                {
                    Id = 19,
                    MovieId = 8,
                    GenreId = 11
                },
                new GenreMovie()
                {
                    Id = 20,
                    MovieId = 9,
                    GenreId = 1
                },
                new GenreMovie()
                {
                    Id = 21,
                    MovieId = 9,
                    GenreId = 2
                },
                new GenreMovie()
                {
                    Id = 22,
                    MovieId = 9,
                    GenreId = 3
                },
                new GenreMovie()
                {
                    Id = 23,
                    MovieId = 9,
                    GenreId = 7
                },
                new GenreMovie()
                {
                    Id = 24,
                    MovieId = 9,
                    GenreId = 12
                }
            });
        }
    }
}