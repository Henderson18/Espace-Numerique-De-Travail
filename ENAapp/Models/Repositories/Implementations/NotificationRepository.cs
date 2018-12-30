using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ENAapp.Models;

namespace ENAapp.Models.Repositories.Implementations
{
    public class NotificationRepository :INotificationRepository
    {
        private readonly bd_entContext context;

        public NotificationRepository(bd_entContext context)
        {
            this.context = context;
        }

        public IQueryable<Notification> AllReciveSMS(string matricule)
        {
            var a = from elt in context.Notification
                    where elt.Matricule ==matricule
                    select elt;
            return a;
        }

        
        public void Delete(Notification notification)
        {
            context.Notification.Remove(notification);
            context.SaveChangesAsync();
        }

        public Notification FindByMat(int id)
        {
            return context.Notification.Find(id);

        }

        public IEnumerable<Notification> List()
        {
            return context.Notification.ToArray();
        }

        public Boolean Save(Notification notification)
        {
         
                context.Notification.Add(notification);
            context.SaveChanges();
                return true;
            
        }
    }
}
