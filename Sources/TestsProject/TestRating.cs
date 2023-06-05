using Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsProject
{
    public class TestRating
    {
        [Fact]
        public void TestEqualsRating() 
        {
            Rating r1 = new Rating(new Account("jean", "aloevera"), 4, "c'est ok tiers cette recette");
            Rating r2 = new Rating(new Account("jean", "aloevera"), 4, "c'est ok tiers cette recette");
            Assert.True(r1.Equals(r2));


            Rating r3 = new Rating(new Account("jean", "aloevera"), 4, "c'est ok tiers cette recette");
            Rating r4 = new Rating(new Account("jeane", "aloevera"), 4, "c'est ok tiers cette recette");
            Assert.False(r3.Equals(r4));

            Rating r5 = new Rating(new Account("jean", "aloevera"), 4, "c'est ok tiers cette recette");
            Rating? r6 = null;
            Assert.False(r5.Equals(r6));

            Assert.False(r3.Equals(new Quantite(4, "g")));
            Assert.False(r3.Equals(null));
        }

        [Fact] 
        public void TestGetHashCode()
        {
            Rating r1 = new Rating(new Account("jean", "aloevera"), 4, "c'est ok tiers cette recette");
            Assert.Equal(r1.Commentaire.GetHashCode(), r1.GetHashCode());
        }
    }
}
