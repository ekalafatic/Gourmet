using System;
using System.Collections.Generic;
using System.Text;

namespace GourmetSp
{
    public class SuscriberRanking : ISuscriber
    {
        public Ranking Ranking { get; set; }
        public bool NotificationsActivated { get; set; }

        public SuscriberRanking(Ranking ranking)
        {
            this.Ranking = ranking;
            NotificationsActivated = true;
        }

        public void Update(Recipe recipe)
        {
            if (this.NotificationsActivated)
            {
                this.Ranking.AddPoints(recipe);
            }
        }
    }
}
