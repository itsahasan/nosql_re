﻿using Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class IncidentDAO : DAO
    {
        IMongoCollection<Incident> collectionIncident;
        public IncidentDAO()
        {
            collectionIncident = Db.GetCollection<Incident>("Incidents");
        }

        public List<Incident> GetAllIncidents()
        {
            return collectionIncident.AsQueryable().ToList<Incident>();
        }
        public void AddIncident(Incident incident)
        {
            collectionIncident.InsertOne(incident);
        }
        public List<Incident> GetTicketsWithStatus(Status status)
        {
            return collectionIncident.Find(ticket => ticket.Status == status).ToList<Incident>();
        }
        public List<Incident> GetTicketsPastDeadline(DateTime dateTime)
        {
            return collectionIncident.Find(ticket => ticket.Deadline < dateTime).ToList<Incident>();
        }
        public List<Incident> GetTickets(User user, Status status)
        {
            return collectionIncident.Find(i => i.Reporter == user.Id && i.Status == status).ToList<Incident>();
        }

        public List<Incident> GetAllUserTickets(User user)
        {
            return collectionIncident.Find(i => i.Reporter == user.Id).ToList<Incident>();
        }
        public void UpdateStatus(Incident incident, Status status)
        {
            incident.Status = status;
            collectionIncident.ReplaceOne(x => x.Id == incident.Id, incident);
        }
    }
}