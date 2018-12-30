using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ENAapp.Models;
using ENAapp.Models.Repositories;
using ENAapp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ENAapp.Controllers
{
    [Route("api/[controller]")]
    public class NotificationsController : Controller
    {
        private readonly ICompteRepository compteRepository;
        private readonly INotificationRepository notificationRepository;

        public NotificationsController(ICompteRepository compteRepository,INotificationRepository notificationRepository)
        {
            this.compteRepository = compteRepository;
            this.notificationRepository = notificationRepository;
        }

        [HttpGet]
        public IEnumerable<Compte> UserOnLigne()
        {
            return this.compteRepository.AllUserConnected();
        }
        [HttpPatch]
        public Boolean SendMessage([FromBody] Notification notification)
        {
            Compte sender;
                sender=this.compteRepository.FindByEmailAsync(notification.Sender);
            Compte compte = this.compteRepository.FindByMatriculeAsync(notification.Matricule);

            notification.Matricule= sender.Matricule;
            notification.Sender = compte.Email;
            notification.Date = DateTime.Now;
            return  this.notificationRepository.Save(notification);
        }
        [HttpPost]
        public IQueryable<Notification> SmsRecus([FromBody] Compte compte)
        {
            return this.notificationRepository.AllReciveSMS(compte.Matricule);
        }
    }
}