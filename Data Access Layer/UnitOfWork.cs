﻿using Data_Access_Layer.Entity;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Repositories;
using Data_Access_Layer.Repositories.Interfaces;

namespace Data_Access_Layer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
        }

        public IMovieRepository Movies => new MovieRepository(_db);
        public IRepository<Genre> Genres => new GenericRepository<Genre>(_db);
        public IRepository<Faq> Faqs => new GenericRepository<Faq>(_db);
        public ICreditCardRepository CreditCards => new CreditCardRepository(_db);
        public IUserRepository Users => new UserRepository(_db);

        public ICommentRepository Comments => new CommentRepository(_db);
        public IRatingRepository Ratings => new RatingRepository(_db);
    }
}