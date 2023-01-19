using BookRentals.Domain;

namespace BookRentals.Persistence
{
    public static class BookSeed
    {
        public static List<Book> Books()
        {
            Guid book1 = new Guid("DF532AE2-E6CC-494F-9472-E78A6D72705E");
            Guid book2 = new Guid("57FD2C45-4343-4A3B-B702-88B94E691D25");
            Guid book3 = new Guid("B9548607-ACB9-444B-9DAE-8330199E420B");
            Guid book4 = new Guid("CDB1D571-D693-4DC5-AECA-D0A8F036EF6E");
            Guid book5 = new Guid("51036971-8A19-43A4-AE77-B250B488838F");

            return new List<Book>
            {
                new Book
                {
                    Id = Guid.NewGuid(),
                    Name = "Nutuk",
                    Author = "Mustafa Kemal Atatürk",
                    Isbn = 9.1,
                    Rented = false,
                },
                new Book
                {
                    Id = book1,
                    Name = "Balıkçı ve Oğlu",
                    Author = "Zülfü Livaneli",
                    Isbn = 8.5,
                    Rented = true,
                },
                new Book
                {
                    Id = Guid.NewGuid(),
                    Name = "İstif Çağı",
                    Author = "James Wallman",
                    Isbn = 7.9,
                    Rented = false,
                },
                new Book
                {
                    Id = book2,
                    Name = "Ben Kirke",
                    Author = "Madeline Miller",
                    Isbn = 8.2,
                    Rented = true,
                },
                new Book
                {
                    Id = book3,
                    Name = "Suç ve Ceza",
                    Author = "Fyodor Mihailoviç Dostoyevski",
                    Isbn = 9.5,
                    Rented = true,
                },
                new Book
                {
                    Id = Guid.NewGuid(),
                    Name = "Amcamın Rüyası",
                    Author = "Fyodor Mihailoviç Dostoyevski",
                    Isbn = 7.0,
                    Rented = false,
                },
                new Book
                {
                    Id = Guid.NewGuid(),
                    Name = "Şeker Portakalı",
                    Author = "Jose Mauro De Vasconcelos",
                    Isbn = 9.3,
                    Rented = false,
                },
                new Book
                {
                    Id = book4,
                    Name = "Kürk Mantolu Madonna",
                    Author = "Sabahattin Ali",
                    Isbn = 9.1,
                    Rented = true,
                },
                new Book
                {
                    Id = book5,
                    Name = "Yalnızım Çünkü Sen Varsın",
                    Author = "Kahraman Tazeoğlu",
                    Isbn = 7.4,
                    Rented = true,
                },
                new Book
                {
                    Id = Guid.NewGuid(),
                    Name = "Uçurtma Avcısı",
                    Author = "Khaled Hosseini",
                    Isbn = 9.2,
                    Rented = false,
                }
            };
        }
    }
}
