using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    internal class ServicePlane : Service<Plane> , IServicePlane
    {
        //private IUnitOfWork uow;

        public ServicePlane(IUnitOfWork uow) : base(uow)
        {
            //this.uow = uow;
        }

        public IList<Passenger> GetPassenger(Plane p)
        {
            //return p.Flights.
            //    SelectMany(f => f.Tickets).
            //    Select(p=>p.Passenger).
            //    ToList() ;
        }

        //public void Add(Plane plane)
        //{
        //    uow.Repository<Plane>().Add(plane);
        //    uow.Save(); 
        //}

        //public void Update(Plane plane)
        //{
        //    uow.Repository<Plane>().Update(plane);
        //    uow.Save();
        //}

        //public IList<Plane> GetAll()
        //{
        //    return uow.Repository<Plane>().GetAll().ToList();
        //}
    }
}
