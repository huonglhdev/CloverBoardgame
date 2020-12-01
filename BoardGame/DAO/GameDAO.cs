using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoardGame.DAO
{

    class GameDAO
    {
        BOARDGAMEDB db = new BOARDGAMEDB();
        public List<tblGame> GetGameByStaff(String search)
        {
            List<tblGame> listGame = new List<tblGame>();
            try
            {
                List<tblGame> tmp = db.tblGame.Include("tblCategory").ToList();
                foreach (tblGame item in tmp)
                {
                    if (item.gameName.ToLower().Contains(search.ToLower().Trim()) && item.gameStatus.Equals("Active"))
                    {
                        listGame.Add(item);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR in GAMEDAO\n" + e.Message);
            }
            return listGame;
        }
        public List<tblGame> GetGame(String search)
        {
            List<tblGame> listGame = new List<tblGame>();
            try
            {
                List<tblGame> tmp = db.tblGame.Include("tblCategory").ToList();
                foreach (tblGame item in tmp)
                {
                    if (item.gameName.ToLower().Contains(search.ToLower().Trim()) && item.gameQuantity > 0 && item.gameStatus.Equals("Active"))
                    {
                        listGame.Add(item);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR in GAMEDAO\n" + e.Message);
            }
            return listGame;
        }
        public tblGame FindById(int gameId)
        {
            tblGame game = null;
            try
            {
                game = db.tblGame.Find(gameId);
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR at gDao\n" + e.Message);
            }
            return game;
        }
        public Boolean Delete(int gameId)
        {
            Boolean check = false;
            try
            {
                tblGame game = FindById(gameId);
                game.gameStatus = "Delete";
                db.Entry(game).State = EntityState.Modified;
                check = db.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR at gDao\n" + e.Message);
            }
            return check;
        }
        public void Add(tblGame game)
        {
            try
            {
                db.tblGame.Add(game);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR in gDao\n" + e.Message);
            }
        }
        public void Update(tblGame game)
        {
            tblGame tmp = new tblGame();
            try
            {
                tmp = FindById(game.gameID);
                tmp.gameName = game.gameName;
                tmp.gamePrice = game.gamePrice;
                tmp.gameQuantity = game.gameQuantity;
                tmp.gameImage = game.gameImage;
                tmp.gameDescription = game.gameDescription;
                tmp.categoryID = game.categoryID;

                db.Entry(tmp).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR in gDao\n" + e.Message);
                MessageBox.Show(e.StackTrace);
            }
        }
        public tblGame FindGame(int gameID)
        {
            var query = (from g in db.tblGame where g.gameID == gameID select g);
            return query.SingleOrDefault();
        }

        public void UpdateListGame(List<tblOrdergame> listOrdergame)
        {
            try
            {
                foreach (tblOrdergame order in listOrdergame)
                {
                    var game = db.tblGame.Where(g => g.gameID == order.gameID).First();
                    game.gameQuantity = game.gameQuantity - order.numOfgame;
                    db.Entry(game).State= System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }catch(Exception e)
            {
                MessageBox.Show("ERROR in gDao\n" + e.Message);
            }
        }
    }
}
