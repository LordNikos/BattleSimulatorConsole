using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace BattleSimulatorConsole
{
    public class TheBatle
    {
        public static Random rnd = new Random();
        public List<Card> myCreature = new List<Card>();
        public List<Card> oponentCreature = new List<Card>();
        public TheBatle() 
        {
            this.myCreature
                .Set_Add(new Card().Set(_Health: 5, _Damage: 5, _MyListCard: myCreature))
                .Set_Add(new Card().Set(_Health: 5, _Damage: 5, _MyListCard: myCreature))
                .Set_Add(new Card().Set(_Health: 5, _Damage: 5, _MyListCard: myCreature))
                .Set_Add(new Card().Set(_Health: 5, _Damage: 5, _MyListCard: myCreature))
                .Set_Add(new Card().Set(_Health: 5, _Damage: 5, _MyListCard: myCreature))
                .Set_Add(new Card().Set(_Health: 5, _Damage: 5, _MyListCard: myCreature))
                .Set_Add(new Card().Set(_Health: 5, _Damage: 5, _MyListCard: myCreature))
            ;
            oponentCreature
                .Set_Add(new Card().Set(_Health: 5, _Damage: 5, _MyListCard: oponentCreature))
                .Set_Add(new Card().Set(_Health: 5, _Damage: 5, _MyListCard: oponentCreature))
                .Set_Add(new Card().Set(_Health: 5, _Damage: 5, _MyListCard: oponentCreature))
                .Set_Add(new Card().Set(_Health: 5, _Damage: 5, _MyListCard: oponentCreature))
                .Set_Add(new Card().Set(_Health: 5, _Damage: 5, _MyListCard: oponentCreature))
                .Set_Add(new Card().Set(_Health: 5, _Damage: 5, _MyListCard: oponentCreature))
                .Set_Add(new Card().Set(_Health: 5, _Damage: 5, _MyListCard: oponentCreature))
            ;
        }
    }
    public static class ExtListCard
    {
        public static List<Card> Set_Add(this List<Card> _this, Card _card)
        {_this.Add(_card);return _this;}
        public static List<Card> Set_WriteThis(this List<Card> _this)
        {_this.ForEach(a => System.Console.WriteLine(a.ToAnonimus().ToString()));return _this;}
    }
    public class Card
    {
        public int Health = 0;
        public int Damage = 0;
        public List<Card> MyListCard = null;
        public Card() { }
        public Card Set(
            Card _this=null
            , System.Nullable<int> _Health = null
            , System.Nullable<int> _Damage = null
            , List<Card> _MyListCard = null
        )
        {
            if (_this != null) this.Set(_this: null, _Health: _this.Health, _Damage: _this.Damage, _MyListCard: _this.MyListCard);
            if (_Health != null) this.Health = _Health.Value;
            if (_Damage != null) this.Damage = _Damage.Value;
            if (_MyListCard != null)this.MyListCard = _MyListCard;
            return this;
        }
        public System.Object ToAnonimus() 
        {return new { Health = this.Health, Damage = this.Damage };}
        /////////////////////////////////////////////////////
        /*
        public static Random rnd = new Random();
        public Card ActOffAttack(List<Card> _targetListCard)
        {
            if (_targetListCard.Count == 0) return this;
            int _id_target = rnd.Next(0, _targetListCard.Count);
            //Attaka
            Card _targetCard = _targetListCard[_id_target];
            _targetCard.Health -= this.Damage;
            //ContraAttaka
            if(_targetCard.Health>=0)this.Health -= _targetCard.Damage;
            return this;
            //Массовые отравления
            //Мясо соседу с права
            //Мясо соседу с лева
        }
        */
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List <Card> myCreature = new List<Card>();
            myCreature
                .Set_Add(new Card().Set(_Health: 5,_Damage: 5,_MyListCard: myCreature))
                .Set_Add(new Card().Set(_Health: 5, _Damage: 5, _MyListCard: myCreature))
                .Set_Add(new Card().Set(_Health: 5, _Damage: 5, _MyListCard: myCreature))
                .Set_Add(new Card().Set(_Health: 5, _Damage: 5, _MyListCard: myCreature))
                .Set_Add(new Card().Set(_Health: 5, _Damage: 5, _MyListCard: myCreature))
                .Set_Add(new Card().Set(_Health: 5, _Damage: 5, _MyListCard: myCreature))
                .Set_Add(new Card().Set(_Health: 5, _Damage: 5, _MyListCard: myCreature))

              //  .Set_Add(new Card().Set(_Health: 5, _Damage: 5, _MyListCard: myCreature))
              //  .Set_Add(new Card().Set(_Health: 5, _Damage: 5, _MyListCard: myCreature))
              //  .Set_Add(new Card().Set(_Health: 5, _Damage: 5, _MyListCard: myCreature))
            // .Set_WriteThis()
            ;
            List<Card> oponentCreature = new List<Card>();
            oponentCreature
                .Set_Add(new Card().Set(_Health: 5, _Damage: 5, _MyListCard: oponentCreature))
                .Set_Add(new Card().Set(_Health: 5, _Damage: 5, _MyListCard: oponentCreature))
                .Set_Add(new Card().Set(_Health: 5, _Damage: 5, _MyListCard: oponentCreature))
                .Set_Add(new Card().Set(_Health: 5, _Damage: 5, _MyListCard: oponentCreature))
                .Set_Add(new Card().Set(_Health: 5, _Damage: 5, _MyListCard: oponentCreature))
                .Set_Add(new Card().Set(_Health: 5, _Damage: 5, _MyListCard: oponentCreature))
                .Set_Add(new Card().Set(_Health: 5, _Damage: 5, _MyListCard: oponentCreature))
            //   .Set_WriteThis()
            ;
            Random rnd = new Random();
            {
                int hoOne = rnd.Next(0, 2);
                List<Card> AtakEr = myCreature;
                List<Card> DefendEr = myCreature;
                if (myCreature.Count > oponentCreature.Count) hoOne = 0;
                if (myCreature.Count < oponentCreature.Count) hoOne = 1;
                if (hoOne == 1) { AtakEr = oponentCreature; } else { DefendEr = oponentCreature; }
                System.Console.WriteLine(AtakEr.Count().ToString() + "//" + DefendEr.Count().ToString());

                for (int i = 0; i < AtakEr.Count; i++)
                {
                    AtakEr[i].ActOffAttack(DefendEr);
                    if (AtakEr[i].Health <= 0) i--;
                    AtakEr = AtakEr.Where(a => a.Health > 0).ToList();
                    DefendEr = DefendEr.Where(a => a.Health > 0).ToList();
                }
                System.Console.WriteLine(AtakEr.Count().ToString() + "//" + DefendEr.Count().ToString());
                for (int i = 0; i < DefendEr.Count; i++)
                {
                    DefendEr[i].ActOffAttack(DefendEr);
                    if (DefendEr[i].Health <= 0) i--;
                    AtakEr = AtakEr.Where(a => a.Health > 0).ToList();
                    DefendEr = DefendEr.Where(a => a.Health > 0).ToList();
                }
                System.Console.WriteLine(AtakEr.Count().ToString() + "//" + DefendEr.Count().ToString());
            }
         //   myCreature.Set_WriteThis();
           // System.Console.WriteLine("///");
//            oponentCreature.Set_WriteThis();






            Console.ReadLine();
        }
    }
}
