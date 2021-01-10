using FormManagementApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormManagementApp.Data
{
    public class FormRepository
    {
       private static  DataContext _context = new DataContext();
        private static List<Form> _form = null;
        static FormRepository()
        {
               _form=_context.FormModels.ToList();
        }

        public static List<Form> Forms
        {
            get
            {
                return _form;
            }
        }
        public static void AddForm(Form form)
        {
            _context.FormModels.Add(form);
            _context.SaveChanges();
        }
        public static Form GetFormById(int id)
        {
            var form = _form.Where(p => p.Id == id).FirstOrDefault();
            return form;
        }
        public static void DeleteForm(int id)
        {
            var form = GetFormById(id);
            if(form != null)
            {
                _context.FormModels.Remove(form);
                _context.SaveChanges();
            }
        }
    }
}