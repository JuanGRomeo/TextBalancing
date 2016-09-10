using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBalancing;

namespace TextBalancingTests
{
    [TestFixture]
    public class TextBalancingTest
    {
        [Test]
        public void givenEmptyText_whenIsBalanced_thenReturnTrue()
        {
            Assert.IsTrue(new TextBalancing.TextBalancing().IsBalanced(""));
        }

        [Test]
        public void givenTextWithoutParentheses_whenIsBalanced_thenReturnTrue()
        {
            Assert.IsTrue(new TextBalancing.TextBalancing().IsBalanced("this does not contain any parentheses"));
        }

        [Test]
        public void givenTextWithBalancedParentheses_whenIsBalanced_thenReturnTrue()
        {
            const string maryAndHerPuppy = "Mary (poor dear) lost her puppy (which she loved so much).";
            Assert.IsTrue(new TextBalancing.TextBalancing().IsBalanced(maryAndHerPuppy));
        }

        [Test]
        public void givenTextWithBalancedBraces_whenIsBalanced_thenReturnTrue()
        {
            const string maryAndHerPuppy = "Mary {poor dear} lost her puppy {which she loved so much}.";
            Assert.IsTrue(new TextBalancing.TextBalancing().IsBalanced(maryAndHerPuppy));
        }

        [Test]
        public void givenTextWithBalancedBraquets_whenIsBalanced_thenReturnTrue()
        {
            const string maryAndHerPuppy = "Mary [poor dear] lost her puppy [which she loved so much].";
            Assert.IsTrue(new TextBalancing.TextBalancing().IsBalanced(maryAndHerPuppy));
        }

        [Test]
        public void givenTextWithUnBalancedLeftParentheses_whenIsBalanced_thenReturnFalse()
        {
            const string unfinishedEquation = "(a + b - (c * d)";
            Assert.IsFalse(new TextBalancing.TextBalancing().IsBalanced(unfinishedEquation));
        }

        [Test]
        public void givenTextWithUnBalancedLeftBraces_whenIsBalanced_thenReturnFalse()
        {
            const string unfinishedEquation = "{a + b - {c * d}";
            Assert.IsFalse(new TextBalancing.TextBalancing().IsBalanced(unfinishedEquation));
        }

        [Test]
        public void givenTextWithUnBalancedLeftBraquets_whenIsBalanced_thenReturnFalse()
        {
            const string unfinishedEquation = "[a + b - [c * d]";
            Assert.IsFalse(new TextBalancing.TextBalancing().IsBalanced(unfinishedEquation));
        }

        [Test]
        public void givenTextWithUnBalancedRightParentheses_whenIsBalanced_thenReturnFalse()
        {
            const string unfinishedEquation = "a + b - (c * d))";
            Assert.IsFalse(new TextBalancing.TextBalancing().IsBalanced(unfinishedEquation));
        }

        [Test]
        public void givenTextWithUnBalancedRightBraces_whenIsBalanced_thenReturnFalse()
        {
            const string unfinishedEquation = "a + b - {c * d}}";
            Assert.IsFalse(new TextBalancing.TextBalancing().IsBalanced(unfinishedEquation));
        }

        [Test]
        public void givenTextWithUnBalancedRightBraquets_whenIsBalanced_thenReturnFalse()
        {
            const string unfinishedEquation = "a + b - [c * d]]";
            Assert.IsFalse(new TextBalancing.TextBalancing().IsBalanced(unfinishedEquation));
        }

        [Test]
        public void givenComplicatedTextWithBalancedParentheses_whenIsBalanced_thenReturnTrue()
        {
            const string weirdText = "d('')b + ((a :-) - b :-( =)) ";
            Assert.IsTrue(new TextBalancing.TextBalancing().IsBalanced(weirdText));
        }

        [Test]
        public void givenComplicatedTextWithBalancedBraces_whenIsBalanced_thenReturnTrue()
        {
            const string weirdText = "d{''}b + {{a :-} - b :-{ =}} ";
            Assert.IsTrue(new TextBalancing.TextBalancing().IsBalanced(weirdText));
        }

        [Test]
        public void givenComplicatedTextWithBalancedBraquets_whenIsBalanced_thenReturnTrue()
        {
            const string weirdText = "d['']b + [[a :-] - b :-[ =]] ";
            Assert.IsTrue(new TextBalancing.TextBalancing().IsBalanced(weirdText));
        }

        [Test]
        public void givenComplicatedTextWithUnnBalancedParentheses_whenIsBalanced_thenReturnFalse()
        {
            const string weirdText = "d)(('')b + ((a :-) - b :-( =)) ";
            Assert.IsFalse(new TextBalancing.TextBalancing().IsBalanced(weirdText));
        }

        [Test]
        public void givenComplicatedTextWithUnnBalancedBraces_whenIsBalanced_thenReturnFalse()
        {
            const string weirdText = "d}{{''}b + {{a :-} - b :-{ =}} ";
            Assert.IsFalse(new TextBalancing.TextBalancing().IsBalanced(weirdText));
        }

        [Test]
        public void givenComplicatedTextWithUnnBalancedBraquets_whenIsBalanced_thenReturnFalse()
        {
            const string weirdText = "d][['']b + [[a :-] - b :-[ =]] ";
            Assert.IsFalse(new TextBalancing.TextBalancing().IsBalanced(weirdText));
        }

        [Test]
        public void givenComplicatedTextWithBalancedSomeSigns_whenIsBalanced_thenReturnTrue()
        {
            const string weirdText = "(1(a{[a - b]})2(b[{b - a}])3(c{x{[[c - d]]}}))";
            Assert.IsTrue(new TextBalancing.TextBalancing().IsBalanced(weirdText));
        }

        [Test]
        public void givenComplicatedTextWithUnnBalancedSomeSigns_whenIsBalanced_thenReturnFalse()
        {
            const string weirdText = "(1(a{[a - b]}})2((b[{b - a}])3(c{x{[[c - d]]}}}))";
            Assert.IsFalse(new TextBalancing.TextBalancing().IsBalanced(weirdText));
        }

        [Test]
        public void givenSuperTextWithoutSigns_whenIsBalanced_thenReturnTrue()
        {
            const string superText = @"
            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent luctus vitae nibh quis scelerisque. Vestibulum semper bibendum justo vel pellentesque. Curabitur ullamcorper nunc efficitur erat placerat venenatis. Ut scelerisque tortor neque, non sollicitudin sem lacinia suscipit. Integer id maximus tortor. Donec venenatis sapien at dolor finibus, in posuere leo fermentum. Fusce pulvinar placerat augue vel viverra. Ut id massa in mi tristique tempus ut ac arcu.
            
            Integer tristique at lacus a pulvinar. Praesent ut felis ante. Aliquam a rutrum turpis. Donec cursus turpis pretium laoreet interdum. Curabitur in sagittis nibh, vitae blandit nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Duis ultricies erat augue, vel gravida diam sodales eget. Suspendisse non ex vel sem sollicitudin sagittis. Integer et elit risus. Fusce in vehicula mi. Etiam mollis, nisi ac dictum ultrices, mi lacus fringilla nibh, quis sagittis urna neque vitae justo. Phasellus suscipit semper nisl a pharetra. Suspendisse potenti. Vivamus efficitur lacus luctus lorem malesuada accumsan. Fusce semper auctor quam non tincidunt.
            
            Pellentesque ultrices cursus rutrum. Vivamus felis nulla, ultricies non molestie vel, luctus ut dolor. Proin fringilla erat vitae ultrices placerat. Sed ullamcorper et arcu eget sagittis. Duis semper eget sapien at tincidunt. Praesent finibus auctor elementum. Nam vel elit hendrerit, commodo velit vel, vehicula nunc. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Quisque pretium lectus porttitor orci consectetur tristique.
            
            Maecenas ut neque eleifend, pretium velit ut, euismod eros. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Sed vulputate libero lorem, at suscipit justo placerat rhoncus. Donec eu scelerisque purus, in accumsan nisl. In eu commodo tortor. Etiam quis condimentum dolor, blandit mattis felis. Sed sit amet metus id felis sodales mollis in vel mi. Mauris malesuada ipsum convallis mollis malesuada. Nulla egestas nisi arcu, ac faucibus arcu congue at. Praesent a interdum nisl.
            
            Nullam scelerisque auctor pulvinar. Maecenas sagittis ultricies bibendum. Praesent eget quam leo. Vestibulum malesuada quis orci vitae pretium. Fusce sollicitudin est id augue vehicula pharetra. Ut consectetur libero ut nulla laoreet tempus. Morbi vitae massa libero. Pellentesque sodales in velit vel feugiat. Vestibulum fermentum consectetur erat, vitae commodo elit rhoncus id. Fusce at ultrices mauris. Aenean ligula eros, consequat sed mauris aliquam, vestibulum malesuada magna. Praesent nec pulvinar massa.";

            Assert.IsTrue(new TextBalancing.TextBalancing().IsBalanced(superText));
        }
    }
}
