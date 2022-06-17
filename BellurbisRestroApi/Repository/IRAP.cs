using Microsoft.EntityFrameworkCore;
using BellurbisRestroApi.Models;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BellurbisRestroApi.Repository
{

    public interface IRAP
    {
        List<RestroMod> RestroIndex();
        List<PlayersMod> PlayerIndex();
        bool RestroCreate(RestroMod R);
        bool PlayerCreate(PlayersMod P);
        RestroMod RestroEdit(int id);
        PlayersMod PlayerEdit(int id);
        bool RestroDelete(int id);
        bool PlayerDelete(int id);
        List<RestroMod> RetrieveRestro(string name);
        List<PlayersMod> RetrievePlayer(string name);
        List<FavRestroPlayer> getall();
        List<FavRestroPlayer> FvrtRes(string name, bool status = true);
        bool RestroPlayerMapping(LinkMod mod);
        ListOfResAndPaly GetbyAge(string RestroName, int age);

    }
    public abstract class RAPAbs : IRAP
    {
        public abstract List<RestroMod> RestroIndex();
        public abstract List<PlayersMod> PlayerIndex();
        public abstract bool RestroCreate(RestroMod R);
        public abstract bool PlayerCreate(PlayersMod P);
        public abstract RestroMod RestroEdit(int id);
        public abstract PlayersMod PlayerEdit(int id);
        public abstract bool RestroDelete(int id);
        public abstract bool PlayerDelete(int id);
        public abstract List<RestroMod> RetrieveRestro(string name);
        public abstract List<PlayersMod> RetrievePlayer(string name);

        public abstract List<FavRestroPlayer> getall();
        public abstract List<FavRestroPlayer> FvrtRes(string name, bool status = true);
        public abstract bool RestroPlayerMapping(LinkMod mod);
        public abstract ListOfResAndPaly GetbyAge(string RestroName, int age);
    }

    public class RAPRepository : RAPAbs
    {
        private readonly TaskContaxt dbcontext = null;

        public RAPRepository(TaskContaxt _dbContxet)
        {
            dbcontext = _dbContxet;
        }

        public override List<RestroMod> RestroIndex()
        {
            return dbcontext.Restrotab.ToList();
        }
        public override List<PlayersMod> PlayerIndex()
        {
            return dbcontext.PlayersTab.ToList();
        }

        public override bool RestroCreate(RestroMod R)
        {
            if (R == null)
            {
                return false;
            }
            else
            {
                if (R.RestroId == 0)
                {
                    dbcontext.Add(R);
                    dbcontext.SaveChanges();
                    return true;
                }
                else
                {
                    dbcontext.Entry(R).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    dbcontext.SaveChanges();
                    return true;
                }
            }
        }

        public override bool PlayerCreate(PlayersMod P)
        {
            if (P == null)
            {
                return false;
            }
            else
            {
                if (P.PlayersId == 0)
                {
                    dbcontext.Add(P);
                    dbcontext.SaveChanges();
                    return true;
                }
                else
                {
                    dbcontext.Entry(P).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    dbcontext.SaveChanges();
                    return true;
                }
            }
        }

        public override RestroMod RestroEdit(int RestroId)
        {
            var a = dbcontext.Restrotab.Find(RestroId);
            return a;
        }
        public override PlayersMod PlayerEdit(int PlayerId)
        {
            var b = dbcontext.PlayersTab.Find(PlayerId);
            return b;
        }
        public override bool RestroDelete(int RestroId)
        {
            var a = dbcontext.Restrotab.Find(RestroId);
            if (a == null)
            {
                return false;
            }
            else
            {
                dbcontext.Remove(a);
                dbcontext.SaveChanges();
                return true;
            }
        }
        public override bool PlayerDelete(int RestroId)
        {
            var b = dbcontext.PlayersTab.Find(RestroId);
            if (b == null)
            {
                return false;
            }
            else
            {
                dbcontext.Remove(b);
                dbcontext.SaveChanges();
                return true;
            }
        }

        public override List<FavRestroPlayer> getall()
        {
            List<FavRestroPlayer> allplayer = new List<FavRestroPlayer>();

            var res = (from pl in dbcontext.PlayersTab
                       from fv in dbcontext.LinkRAP
                       from rt in dbcontext.Restrotab
                       where pl.PlayersId == fv.PlayersId
                       && rt.RestroId == fv.RestroId
                       where pl.PlayersId > 0
                       select new
                       {
                           pl = pl,
                           rt = rt,
                           fv = fv
                       }).ToList();

            foreach (var item in res)
            {
                FavRestroPlayer obj = new FavRestroPlayer();

                obj.pl = item.pl;
                obj.rt = item.rt;
                obj.fv = item.fv;
                allplayer.Add(obj);
            }
            return allplayer;
        }

        public override List<RestroMod> RetrieveRestro(string Name)
        {
            var obj = dbcontext.Restrotab.Where(Models => Models.RestroName == Name).ToList();
            return obj;
        }
        public override List<PlayersMod> RetrievePlayer(string Name)
        {
            var obj = dbcontext.PlayersTab.Where(Models => Models.PlayerName == Name).ToList();
            return obj;
        }
        public override List<FavRestroPlayer> FvrtRes(string name, bool status = true)
        {
            List<FavRestroPlayer> ListRest = new List<FavRestroPlayer>();

            if (name != null && name != "")
            {
                var res = (from pl in dbcontext.PlayersTab
                           from fv in dbcontext.LinkRAP
                           from rt in dbcontext.Restrotab
                           where pl.PlayersId == fv.PlayersId
                           && rt.RestroId == fv.RestroId
                           && name.Equals(pl.PlayerName)
                           && fv.Fav == status
                           select new
                           {
                               pl = pl,
                               rt = rt,
                               fv = fv
                           }).ToList();
                //select new
                //{
                //    PlayersId = pt.PlayersId,
                //    PlayerName = pt.PlayerName,
                //    PlayerDOB = pt.PlayerDOB.ToString(),
                //    PlayerPrimaryAdd = pt.PlayerPrimaryAdd,
                //    PlayerAlternateAdd = pt.PlayerAlternateAdd,
                //    PlayerOfficeAdd = pt.PlayerOfficeAdd,
                //    PlayerMobNo = pt.PlayerMobNo,
                //    PlayerEmail = pt.PlayerEmail,
                //    PlayerDL = pt.PlayerDL,
                //    PlayerPassport = pt.PlayerPassport,
                //    PlayerCountry = pt.PlayerCountry,
                //    PlayerState = pt.PlayerState,
                //    PlayerCity = pt.PlayerCity,
                //    AddressLine1 = pt.AddressLine1,
                //    AddressLine2 = pt.AddressLine2,
                //    PlayerPostal = pt.PlayerPostal,
                //    RestroId = rt.RestroId,
                //    RestroName = rt.RestroName,
                //    RestroAddress = rt.RestroAddress,
                //    RestroContact = rt.RestroContact
                //}
                //).ToList();

                foreach (var item in res)
                {
                    FavRestroPlayer obj = new FavRestroPlayer();

                    obj.pl = item.pl;
                    obj.rt = item.rt;
                    obj.fv = item.fv;
                    ListRest.Add(obj);
                }
            }
            return ListRest;
        }

        public override bool RestroPlayerMapping(LinkMod mod)
        {
            if (mod == null)
            {
                return false;
            }
            else
            {
                if (mod.PlayersId >= 1 && mod.RestroId >= 1)

                {
                    // if(mod.Fav==null)
                    dbcontext.Add(mod);
                    dbcontext.SaveChanges();
                    return true;
                }

                else
                {
                    return false;
                }
            }
        }

        public override ListOfResAndPaly GetbyAge(string RestroName, int age)
        {
            ListOfResAndPaly lst = new ListOfResAndPaly();
            var RestaurantCollection = dbcontext.Restrotab.FirstOrDefault(x => x.RestroName == RestroName);
            List<PlayersMod> placol = new List<PlayersMod>();
            List<PlayersMod> news = new List<PlayersMod>();

            if (RestaurantCollection != null)
            {
                var restaurentId = RestaurantCollection.RestroId;

                var LinkDetail = dbcontext.LinkRAP.Where(x => x.RestroId == restaurentId).ToList();
                foreach (var item in LinkDetail)
                {

                    var abc = dbcontext.PlayersTab.Where(x => x.PlayersId == item.PlayersId).FirstOrDefault();
                    news.Add(abc);

                }

                foreach (var item in news)
                {
                    
                    var years = DateTime.Now.Year - Convert.ToDateTime(item.PlayerDOB).Year;
                    
                    if (years >= age)
                    {
                        placol.Add(item);
                    }
                    
                    years = 0;
                }
                List<FavRestroPlayer> res = new List<FavRestroPlayer>();
                var areas = (from pl in dbcontext.PlayersTab
                             from rt in dbcontext.Restrotab
                             from fv in dbcontext.LinkRAP
                             where pl.PlayersId == fv.PlayersId
                             && rt.RestroId == fv.RestroId
                             select new
                             {
                                 pl = pl,
                                 rt = rt,
                                 fv = fv
                             }).ToList();
                foreach (var item in areas)
                {
                    FavRestroPlayer obj1 = new FavRestroPlayer();

                    obj1.pl = item.pl;
                    obj1.rt = item.rt;
                    obj1.fv = item.fv;
                    res.Add(obj1);
                }

                
                lst.rt = RestaurantCollection;
                lst.pls = placol;

                //List<FavRestroPlayer> res = new List<FavRestroPlayer>();
                //var areas = (from pl in dbcontext.PlayersTab
                //             from rt in dbcontext.Restrotab
                //             from fv in dbcontext.LinkRAP
                //             where pl.PlayersId == fv.PlayersId
                //             && rt.RestroId == fv.RestroId
                //             let years = DateTime.Now.Year - Convert.ToDateTime(pl.PlayerDOB).Year
                //             let birthdayThisYear = Convert.ToDateTime(pl.PlayerDOB).AddYears(years)
                //             select new
                //             {
                //                 pl = pl,
                //                 rt = rt,
                //                 fv = fv,
                //                 Age = birthdayThisYear > DateTime.Now ? years - 1 : years
                //             }).ToList();


                //foreach (var item in areas)
                //    {
                //    //int year = Convert.ToInt32(item.Age);

                //    FavRestroPlayer Fp = new FavRestroPlayer();

                //    if (item.Age >= 60 )
                //    {
                //        string s = "";
                //        s = item.Age.ToString();
                //        obj.Add(s);
                //        Fp.pl = item.pl;
                //        Fp.rt = item.rt;
                //        Fp.fv = item.fv;
                //        res.Add(Fp);
                //    }
                //    else
                //    {
                //        return obj;
                //    }
                //    }

                
            }

            return lst;
        }
    }
}
