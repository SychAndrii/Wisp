using Discord.Interactions;
using Discord.Models;

namespace Discord.Modules
{
    public class ViewAllExercisesModule : InteractionModuleBase<SocketInteractionContext>
    {
        private static readonly List<Exercise> Exercises = new List<Exercise>
        {
            new Exercise
            {
                Name = "Push-Up",
                Difficulty = "Beginner",
                Description = "A basic bodyweight exercise that targets the chest, shoulders, and triceps.",
                Equipment = "None",
                PrimaryMuscles = new List<string> { "Chest" },
                SecondaryMuscles = new List<string> { "Shoulders", "Triceps" },
                Metrics = new List<string> { "Reps" },
                ImageURL = "https://kinxlearning.com/cdn/shop/files/Pushup_1400x.jpg?v=1705765225",
                VideoURL = "https://www.youtube.com/shorts/cqIaBJ2Xrh8"
            },
            new Exercise
            {
                Name = "Squat",
                Difficulty = "Intermediate",
                Description = "A compound exercise that primarily targets the lower body muscles.",
                Equipment = "None",
                PrimaryMuscles = new List<string> { "Quadriceps" },
                SecondaryMuscles = new List<string> { "Glutes", "Hamstrings", "Core" },
                Metrics = new List<string> { "Reps" },
                ImageURL = "https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png"
            },
            new Exercise
            {
                Name = "Deadlift",
                Difficulty = "Advanced",
                Description = "A compound exercise that targets multiple muscle groups, primarily the back and legs.",
                Equipment = "Barbell",
                PrimaryMuscles = new List<string> { "Lower Back", "Glutes" },
                SecondaryMuscles = new List<string> { "Hamstrings", "Core" },
                Metrics = new List<string> { "Weight", "Reps" },
                ImageURL = "https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png"
            },
            new Exercise
            {
                Name = "Pull-Up",
                Difficulty = "Advanced",
                Description = "A bodyweight exercise that strengthens the back and arms.",
                Equipment = "Pull-Up Bar",
                PrimaryMuscles = new List<string> { "Lats" },
                SecondaryMuscles = new List<string> { "Biceps", "Shoulders" },
                Metrics = new List<string> { "Reps" },
                ImageURL = "https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png"
            },
        };

        private static int currentPage = 0;

        private List<Embed> GetCurrentEmbeds()
        {
            var embeds = new List<Embed>();

            for (int i = 0; i < 2 && currentPage + i < Exercises.Count; i++)
            {
                var exercise = Exercises[currentPage + i];
                var embedBuilder = new EmbedBuilder()
                    .WithTitle(exercise.Name)
                    .WithDescription(exercise.Description ?? "No description available.")
                    .AddField("Difficulty", exercise.Difficulty, inline: true)
                    .AddField("Equipment", exercise.Equipment ?? "None", inline: true)
                    .AddField("Primary Muscles", string.Join(", ", exercise.PrimaryMuscles), inline: true)
                    .AddField("Secondary Muscles", string.Join(", ", exercise.SecondaryMuscles), inline: true)
                    .WithImageUrl(exercise.ImageURL)
                    .WithColor(Color.Blue);

                if (!string.IsNullOrEmpty(exercise.VideoURL))
                {
                    embedBuilder.AddField("Watch Video", $"[Click here to watch the video]({exercise.VideoURL})", inline: false);
                }

                embeds.Add(embedBuilder.Build());
            }

            return embeds;
        }

        [SlashCommand("view-all", "View all available exercises")]
        public async Task ViewAllExercises()
        {
            if (Exercises.Count == 0)
            {
                await RespondAsync("No exercises found!");
                return;
            }

            var embeds = GetCurrentEmbeds().ToArray();
            await RespondAsync(embeds: embeds, components: GetPaginationButtons(disablePrevious: true, disableNext: Exercises.Count <= 2));
        }

        [ComponentInteraction("next_button")]
        public async Task SwitchNext()
        {
            if (!Context.Interaction.HasResponded)
            {
                await DeferAsync();
            }

            // Move forward by 2 exercises per page
            if (currentPage + 2 < Exercises.Count)
            {
                currentPage += 2;
            }

            var components = GetPaginationButtons(disablePrevious: currentPage == 0, disableNext: currentPage + 2 >= Exercises.Count);
            await Context.Interaction.ModifyOriginalResponseAsync(msg =>
            {
                msg.Embeds = GetCurrentEmbeds().ToArray();
                msg.Components = components;
            });
        }

        [ComponentInteraction("previous_button")]
        public async Task SwitchPrevious()
        {
            if (!Context.Interaction.HasResponded)
            {
                await DeferAsync();
            }

            // Move back by 2 exercises per page
            if (currentPage - 2 >= 0)
            {
                currentPage -= 2;
            }

            var components = GetPaginationButtons(disablePrevious: currentPage == 0, disableNext: currentPage + 2 >= Exercises.Count);
            await Context.Interaction.ModifyOriginalResponseAsync(msg =>
            {
                msg.Embeds = GetCurrentEmbeds().ToArray();
                msg.Components = components;
            });
        }

        private MessageComponent GetPaginationButtons(bool disablePrevious, bool disableNext)
        {
            var previousButton = new ButtonBuilder()
                .WithLabel("Previous")
                .WithCustomId("previous_button")
                .WithStyle(ButtonStyle.Primary)
                .WithDisabled(disablePrevious);

            var nextButton = new ButtonBuilder()
                .WithLabel("Next")
                .WithCustomId("next_button")
                .WithStyle(ButtonStyle.Primary)
                .WithDisabled(disableNext);

            return new ComponentBuilder()
                .WithButton(previousButton)
                .WithButton(nextButton)
                .Build();
        }
    }
}