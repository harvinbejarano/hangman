using HangMan.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
		/// The DbContext
		/// </summary>
		private DbContext _dbContext;



        public UnitOfWork(hangmanEntities context)
        {
            _dbContext = context;
        }


        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                    _dbContext = null;
                }
            }
        }
    }
}
