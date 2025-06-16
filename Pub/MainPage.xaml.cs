using Plugin.MauiMTAdmob;

namespace Pub
{
    public partial class MainPage : ContentPage
    {
        const string RewardedAdId = "ca-app-pub-3940256099942544/5224354917"; // ID test Google

        public MainPage()
        {
            InitializeComponent();

            // Charger la rewarded ad dès le départ
            CrossMauiMTAdmob.Current.LoadRewarded(RewardedAdId);

            var showRewardedButton = new Button { Text = "Show Rewarded Ad" };
            showRewardedButton.Clicked += async (s, e) =>
            {
                if (CrossMauiMTAdmob.Current.IsRewardedLoaded())
                {
                    // Attache le handler AVANT d'afficher la pub
                    CrossMauiMTAdmob.Current.OnUserEarnedReward += OnUserEarnedReward;
                    CrossMauiMTAdmob.Current.ShowRewarded();
                }
                else
                {
                    await DisplayAlert("Info", "Rewarded Ad is not loaded yet.", "OK");
                }
            };

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children = { showRewardedButton }
            };
        }

        private void OnUserEarnedReward(object sender, EventArgs e)
        {
            // L'utilisateur a regardé la pub et mérite sa récompense
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert("Reward", "You earned the reward!", "Thanks");
            });

            // Détache l'événement pour éviter les doublons
            CrossMauiMTAdmob.Current.OnUserEarnedReward -= OnUserEarnedReward;

            // Recharge une nouvelle rewarded ad pour la prochaine fois !
            CrossMauiMTAdmob.Current.LoadRewarded(RewardedAdId);
        }
    }
}
