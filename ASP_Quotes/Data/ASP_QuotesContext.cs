using Microsoft.EntityFrameworkCore;
using System;

namespace ASP_Quotes.Models
{
    public class ASP_QuotesContext : DbContext
    {
        public ASP_QuotesContext (DbContextOptions<ASP_QuotesContext> options)
            : base(options)
        {
        }

        public DbSet<Quotes> Quotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quotes>().HasData(
                new Quotes { QuotesId = 1, Author="Вадим Зеланд", Text= "Чудо произойдет только в том случае, если вы сломаете привычный стереотип и будете думать не о средствах достижения, а о самой цели",InsertDate=DateTime.Now },
                new Quotes { QuotesId=2,Author="Вадим Зеланд", Text= "Вы никогда ничего не измените, если будете бороться с существующим. Чтобы что-то изменить, постройте новую модель и сделайте существующее устаревшим.", InsertDate=DateTime.Now},
                new Quotes { QuotesId = 3, Author = "Генри Форд", Text = "Везет человеку, которому удается уйти из этого мира живым.", InsertDate = DateTime.Now },
                new Quotes { QuotesId = 4, Author = "Альберт Эйнштейн", Text = "Я научился смотреть на смерть как на старый долг, который рано или поздно придется заплатить", InsertDate = DateTime.Now },
                new Quotes { QuotesId = 5, Author = "Кин Хаббард", Text = "Что бы там ни было, никогда не принимайте жизнь слишком всерьез – вам из нее живьем все равно не выбраться", InsertDate = DateTime.Now });





        }
    }
}
