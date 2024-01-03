using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class IncidentService
    {
        IncidentDAO incidentDAO;
        public IncidentService()
        {
            incidentDAO = new IncidentDAO();
        }

        public List<Incident> GetAllIncidents()
        {
            return incidentDAO.GetAllIncidents();
        }
        public void AddIncident(Incident incident)
        {
            incidentDAO.AddIncident(incident);
        }
        public void UpdateStatus(Incident incident, Status status)
        {
            incidentDAO.UpdateStatus(incident, status);
        }
    }
}
