using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DoAn.Model;
using Xamarin.Forms;
using DoAn.Services;
using Firebase.Database;

namespace DoAn.OriginalPage.Tips
{
    public partial class TipPage : ContentPage
    {
        List<Tip> tips;
        DBFirebase services = new DBFirebase();

        public TipPage()
        {
            InitializeComponent();
            //BindingContext = this;

            //Tip t = new Tip();
            //t.Id = 5;
            //t.Image = "todolist3.jpeg";
            //t.Tag = "Project management";
            //t.Title = "5 Project Management Tips for Non-Project Managers";
            //t.Content = "1. Begin with the end in mind.\nThrough his years in the industry, Joe Griffin—certified PMP and associate teaching professor in Northeastern’s Master of Science in Project Management program—has discovered that all successful projects have a specific starting and ending point. “Like a marathon runner envisioning the finish line, if you understand that arc and constantly envision your goal, you’ll remain true to it,” he explains. Envisioning your end goal is also impactful when keeping distractions at bay and remaining focused and on-task through the completion of your work.\n\n2. Understand your goal.\nWhen you’re managing any kind of project, it is essential that you understand your overall mission before diving deeply into the many tasks required to complete it, Griffin explains.\n\nDuring the process, for example, you may find yourself confronted by situations that aim to influence you to change the project’s direction. When situations like this arise, Griffin suggests asking yourself, “What do I need to produce for these influencers to meet their expectations?”\n\n“These items are considered ‘mission critical’ and, ideally, you should feel comfortable declining other requests. Really,” he says.\n\nAlthough it may seem daunting to say “No” to a request (particularly if it’s from a supervisor,) when you have taken the time to understand the vision of the project beforehand, what you’ve actually done is develop the tools and language needed to properly articulate the realistic goals of the work. In doing this, you will help keep everyone on track toward that predetermined objective.\n\n3. Be considerate.\nOn the personal side of project management, it’s important to take time to communicate with family and friends about the scope of your work, your deadlines, and the amount of focus required to accomplish your goals. This will create a much-needed understanding of your limitations as you work toward the project’s completion.\n\n“When you’re managing a project, it’s easy to get so bogged down that you forget life is actually going on without you,” Griffin says. “Come up for air and let your colleagues and family understand your needs.”\n\nFrom an in-office angle, it’s important to communicate with your team members about your schedule, working style, and personal life in order to manage expectations.\n\n“Keep your colleagues and classmates informed about your schedule,” Griffin says. “When do you work best? What time do you reserve for personal commitments? Be clear and firm.”\n\n4. Manage risks.\n“Risk management is hugely important to project management,” Griffin says, offering the example of an adult learner trying to go back to school while simultaneously balancing work and family responsibilities. He explains the importance of identifying what the risks are in this instance and developing a “risk response strategy” that can be implemented if things don’t go according to plan.\n\nAn example of a risk-response strategy within this scenario, “could be as simple as realizing you don’t work well at night,” he says. “Maybe you’re a morning person. Plan a classwork strategy that mitigates the risk of unproductivity. Set aside time in the morning for working and let people know that that is ‘your’ time. Set up a process that works for you—even if it’s at 2 a.m.—and stick to it.”\n\n5. Avoid perfectionism.\nIt’s human nature to aim for perfection when taking ownership of a project or task, yet there are dozens of factors and unforeseen circumstances that have the ability to negatively influence outcomes. For this reason, Griffin explains that employees should forget about perfectionism and instead focus on simply meeting the predetermined project goals. If the completed project meets the overall expectations of its stakeholders, then you should feel as if your project was a success.";
            //services.SaveTip(t);

            //var tips = services.GetAllTips();
            //TipsCarouselView.ItemsSource = (System.Collections.IEnumerable)tips;
            Init();
            BindingContext = tips;

        }

        //protected override async void OnAppearing()
        //{
        //    base.OnAppearing();
        //    tips = await services.GetTheFirst4Tips();
        //    TipsCarouselView.ItemsSource = tips;
        //}

        async void Init()
        {
            tips = await services.GetTheFirst4Tips();
            TipsCarouselView.ItemsSource = tips;
        }

        void MoreTips_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new MoreTips());
        }

        void TipsCarouselView_CurrentItemChanged(System.Object sender, Xamarin.Forms.CurrentItemChangedEventArgs e)
        {
            var cur = e.CurrentItem as Tip;
            TipContent.Text = cur.Content;
        }
    }
}

