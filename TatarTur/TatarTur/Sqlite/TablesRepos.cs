using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

namespace TatarTur.Sqlite
{
    public class TablesRepos
    {
        SQLiteConnection database;
        public TablesRepos(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<User>();
            database.CreateTable<City>();
            database.CreateTable<Review>();
            database.CreateTable<Ticket>();
            database.CreateTable<Tour>();
            database.CreateTable<UserTicket>();
        }
        public List<City> GetCities()
        {
            return database.Table<City>().ToList();
        }

        public City GetCity(int id)
        {
            return database.Get<City>(id);
        }

        public int DeleteCity(int id)
        {
            return database.Delete<City>(id);
        }

        public int SaveCity(City item)
        {
            
            
                return database.Insert(item);
            
        }

        public IEnumerable<User> GetUsers()
        {
            return database.Table<User>().ToList();
        }

        public User GetUser(int id)
        {
            return database.Get<User>(id);
        }

        public int DeleteUser(int id)
        {
            return database.Delete<User>(id);
        }

        public int SaveUser(User item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }

        public IEnumerable<Review> GetReviews()
        {
            return database.Table<Review>().ToList();
        }

        public IEnumerable<Review> GetReviewId(int id)
        {
            return database.Table<Review>().Where(a => a.IdTour == id).ToList();
        }

        public IEnumerable<Review> GetReviewsId(int id)
        {
            return database.Table<Review>().Where(a => a.IdUser != id);
        }

        public Review GetReview(int id)
        {
            return database.Get<Review>(id);
        }

        public int DeleteReview(int id)
        {
            return database.Delete<Review>(id);
        }

        public int SaveReview(Review item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }

        public IEnumerable<Tour> GetTours()
        {
            return database.Table<Tour>().ToList();
        }

        public Tour GetTour(int id)
        {
            return database.Get<Tour>(id);
        }

        public IEnumerable<Tour> GetTourIdCity(int idCity)
        {
            return database.Table<Tour>().Where(a => a.IdCity == idCity).ToList();
        }

        public int DeleteTour(int id)
        {
            return database.Delete<Tour>(id);
        }

        public int SaveTour(Tour item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }

        public IEnumerable<Ticket> GetTickets()
        {
            return database.Table<Ticket>().ToList();
        }

        public Ticket GetTicket(int id)
        {
            return database.Get<Ticket>(id);
        }

        public IEnumerable<Ticket> GetTicketIdTour(int idTour)
        {
            return database.Table<Ticket>().Where(a => a.IdTour == idTour).ToList();
        }

        public int DeleteTicket(int id)
        {
            return database.Delete<Ticket>(id);
        }

        public int SaveTicket(Ticket item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
        public IEnumerable<UserTicket> GetUserTickets(int idUser)
        {
            return database.Table<UserTicket>().Where(a => a.IdUser == idUser).ToList();
        }

        public int DeleteUserTicket(int id)
        {
            return database.Delete<UserTicket>(id);
        }

        public int SaveUserTicket(UserTicket item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
        public void CityTemplate()
        {
            City city = new City();
            city.Name = "Казань";
            SaveCity(city);
            city.Name = "Бугульма";
            SaveCity(city);
            city.Name = "Азнакаево";
            SaveCity(city);
            city.Name = "Альметьевск";
            SaveCity(city);
            city.Name = "Булгар";
            SaveCity(city);
            city.Name = "Лениногорск";
            SaveCity(city);
            city.Name = "Нижнекамск";
            SaveCity(city);
            city.Name = "Набережные Челны";
            SaveCity(city);
            city.Name = "Чистополь";
            SaveCity(city);
            city.Name = "Елабуга";
            SaveCity(city);
            city.Name = "Мамадышы";
            SaveCity(city);
        }
        public bool IsNewUser()
        {
            return App.Database.GetUsers().FirstOrDefault() == null;
        }
    }
}
