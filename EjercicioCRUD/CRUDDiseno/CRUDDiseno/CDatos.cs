using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace CRUDDiseno
{
    internal class CDatos
    {
        dbEjemploEntities db;
        public void Create(Persona pPersona)
        {
            try
            {
                using (db = new dbEjemploEntities())
                {
                    db.Persona.Add(pPersona);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }
        public List<Persona> Read()
        {
            try
            {
                using (db = new dbEjemploEntities())
                {
                   return db.Persona.ToList();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public void Update(Persona pPersona)
        {
            try
            {
                using(db = new dbEjemploEntities()) 
                {
                    db.Entry(pPersona).State = System.Data.EntityState.Modified;
                    db.SaveChanges();
                 
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Delete(int pID) 
        {
            try
            {
                using (db = new dbEjemploEntities())
                {
                    db.Persona.Remove(db.Persona.Single
                        (p => p.Id == pID));
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public List<Persona> buscarID(int pID)
        {
            try
            {
                using (db = new dbEjemploEntities())
                {
                    return db.Persona.Where(p=>p.Id== pID).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public List<Persona> buscarNom(string pNom)
        {
            try
            {
                using (db = new dbEjemploEntities())
                {
                    return db.Persona.Where(p => p.Nombre.Contains(pNom)).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

    }
}
