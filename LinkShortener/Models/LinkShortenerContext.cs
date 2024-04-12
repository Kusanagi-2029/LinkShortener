using Microsoft.EntityFrameworkCore;

namespace LinkShortener.Models;

public class LinkShortenerContext : DbContext
{
    
    public LinkShortenerContext(DbContextOptions<LinkShortenerContext> options) : base(options)
    {
        /*Ошибка "AddDbContext was called with configuration, but the context type 'ApplicationDbContext' only
         declares a parameterless constructor" указывает на то, что класс ApplicationDbContext должен предоставлять 
         публичный конструктор с параметром типа DbContextOptions<ApplicationDbContext>. Это необходимо для передачи 
         конфигурации контекста из AddDbContext в сам контекст базы данных.
         Для исправления этой ошибки нам необходимо изменить класс ApplicationDbContext, чтобы он предоставлял 
         требуемый конструктор и конфигурация контекста базы данных будет передаваться корректно из метода 
         AddDbContext в класс контекста.*/
    }

    
    public DbSet<ShortLinks> ShortLinks { get; set; }
    // Другие модели
}
