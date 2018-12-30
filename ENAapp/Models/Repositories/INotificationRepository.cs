using System;
using System.Collections.Generic;
using System.Linq;
using ENAapp.Models;
using System.Threading.Tasks;

namespace ENAapp.Models.Repositories
{
   public  interface INotificationRepository
    {
        IEnumerable<Notification> List();
        Notification FindByMat(int id);
        Boolean Save(Notification notification);
        void Delete(Notification notification);
        IQueryable<Notification> AllReciveSMS(string email);
    }
}
