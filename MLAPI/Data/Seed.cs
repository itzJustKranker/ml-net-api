namespace MLAPI.Data
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore.Internal;
    using Models;

    public class Seed
    {
        private readonly DataContext _context;

        public Seed(DataContext context)
        {
            _context = context;
        }

        public async Task SeedIfEmpty()
        {
            if (!_context.ModelInputs.Any())
                await SeedInputs();
        }

        private async Task SeedInputs()
        {
            _context.ModelInputs.Add(new DbModelInput()
            {
                Sentiment = true,
                SentimentText = "==You're cool== You seem like a really cool guy... *bursts out laughing at sarcasm*."
            });
            _context.ModelInputs.Add(new DbModelInput()
            {
                Sentiment = false,
                SentimentText = "I just want to point something out (and I'm in no way a supporter of the strange old git), but he is referred to as Dear Leader, and his father was referred to as Great Leader."
            });
            _context.ModelInputs.Add(new DbModelInput()
            {
                Sentiment = true,
                SentimentText = "==RUDE== Dude, you are rude upload that carl picture back, or else."
            });
            _context.ModelInputs.Add(new DbModelInput()
            {
                Sentiment = false,
                SentimentText = ": I know you listed your English as on the \"level 2\", but don't worry, you seem to be doing nicely otherwise, judging by the same page - so don't be taken aback. I just wanted to know if you were aware of what you wrote, and think it's an interesting case. : I would write that sentence simply as \"Theoretically I am an altruist, but only by word, not by my actions.\". : PS. You can reply to me on this same page, as I have it on my watchlist."
            });
            _context.ModelInputs.Add(new DbModelInput()
            {
                Sentiment = true,
                SentimentText = "== Conflict of interest == You are a person who is doing some sort of harm to this lady Saman Hasnain.. It is apparent that you are making sure that her name is defamed.... Okay no problem... Will get a better source... you are playing dirty... DOG Sonisona"
            });
            _context.ModelInputs.Add(new DbModelInput()
            {
                Sentiment = true,
                SentimentText = ":the category was unnecesary, as explained in my edit summary. Your threats are disgrace to wikipedia."
            });
            _context.ModelInputs.Add(new DbModelInput()
            {
                Sentiment = true,
                SentimentText = ":You call MacDonald's a part of your \"culture\"? Nonsense! Spend some 10 years in France, and then you will have a hint of what Culture is!"
            });
            _context.ModelInputs.Add(new DbModelInput()
            {
                Sentiment = true,
                SentimentText = "Grow up you biased child."
            });
            _context.ModelInputs.Add(new DbModelInput()
            {
                Sentiment = true,
                SentimentText = "Stop trolling, zapatancas, calling me a liar merely demonstartes that you arer Zapatancas. You may choose to chase every legitimate editor from this site and ignore me but I am an editor with a record that isnt 99% trolling and therefore my wishes are not to be completely ignored by a sockpuppet like yourself. The consensus is overwhelmingly against you and your trollin g lover Zapatancas,"
            });
            _context.ModelInputs.Add(new DbModelInput()
            {
                Sentiment = false,
                SentimentText = "I saw it before watching the episode. Oh well."
            });
            _context.ModelInputs.Add(new DbModelInput()
            {
                Sentiment = false,
                SentimentText = "This is British form and does not correspond to French nobiliary rules, which, in any case, are defunct, given that French noble titles were rendered obsolete more than a century ago. I think that, technically, she is merely Raine Spencer, having retrieved her previous surname upon her divorce from Chambrun. (And during the French marriage, she was not Countess of Chambrun, she was Countess Jean-Francois de Chambrun, and, as per French usage, would be referred to as Mme de Chambrun, with the title used only by servants and so-called inferiors.)"
            });
            _context.ModelInputs.Add(new DbModelInput()
            {
                Sentiment = true,
                SentimentText = "Today was the worst day ever"
            });
            _context.ModelInputs.Add(new DbModelInput()
            {
                Sentiment = false,
                SentimentText = "I'm so happy"
            });
            _context.ModelInputs.Add(new DbModelInput()
            {
                Sentiment = false,
                SentimentText = "This is the best game I've ever played"
            });
            _context.ModelInputs.Add(new DbModelInput()
            {
                Sentiment = false,
                SentimentText = "This game is so dang good man"
            });
            _context.ModelInputs.Add(new DbModelInput()
            {
                Sentiment = false,
                SentimentText = "Such an incredible game. Absolutely loved it."
            });
            _context.ModelInputs.Add(new DbModelInput()
            {
                Sentiment = false,
                SentimentText = "Until the next game comes out, this game is undisputedly the best Xbox game of all time"
            });
            _context.ModelInputs.Add(new DbModelInput()
            {
                Sentiment = true,
                SentimentText = "This game without that feature would be the worst fighting game ever. Y'all really overrate that franchise."
            });

            await _context.SaveChangesAsync();
        }
    }
}