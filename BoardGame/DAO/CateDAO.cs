using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoardGame.DAO
{
    class CateDAO
    {
        BOARDGAMEDB db = new BOARDGAMEDB();
        public List<tblCategory> GetCate()
        {
            List<tblCategory> listCate = null;
            try
            {
                listCate = db.tblCategory.ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR at CateDAO");
            }
            return listCate;
        }
    }
}
