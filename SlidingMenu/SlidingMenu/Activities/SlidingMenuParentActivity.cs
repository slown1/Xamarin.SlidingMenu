﻿using System;
using System.Collections.Generic;
using Android.App;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;
using Android.OS;
using SlidingMenu.Adapters;
using SlidingMenu.Application;
using SlidingMenu.Helper;
using SlidingMenu.Models;
using Xamarin.ActionbarSherlockBinding.App;

namespace SlidingMenu
{
    [Activity(Label = "SlidingMenuParentActivity", Icon = "@drawable/icon")]
    public abstract class SlidingMenuParentActivity : SherlockFragmentActivity, ExpandableListView.IOnChildClickListener
    {
        protected DrawerLayout mDrawerLayout;
        protected ExpandableListView mDrawerListLeft;
        protected ListView mDrawerListRight;
        protected ActionBarDrawerToggle mDrawerToggle;

        protected string mDrawerTitle;
        protected string mTitle;

        protected List<Section> settings;
        protected SettingsAdapter settingsAdapter;
        private bool sliderInitialized = false;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            try
            {
                SetContentView(Resource.Layout.activity_slidingmenu);
                InitializeUIElements();
                if (bundle == null)
                {
                    SelectItem();
                }
            }
            catch (Exception ex)
            {
                //NotificationService.showWarningCrouton("Failed at onCreate");
                ex.ToString();
            }
        }

        protected void InitializeUIElements()
        {

            if (sliderInitialized == false)
            {
                try
                {
                    mTitle = mDrawerTitle = Title;
                    mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
                    mDrawerListLeft = FindViewById<ExpandableListView>(Resource.Id.left_drawer);
                    // no need to actually populate the right menu as obviously it would have different items and functionality than the left
                    mDrawerListRight = FindViewById<ListView>(Resource.Id.right_drawer);

                    // set a custom shadow that overlays the main content when the drawer opens
                    mDrawerLayout.SetDrawerShadow(Resource.Drawable.drawer_shadow, GravityCompat.Start);
                    mDrawerLayout.SetDrawerShadow(Resource.Drawable.drawer_shadow, GravityCompat.End);
                    // set up the drawer's list view with items and click listener

                    mDrawerListRight.ItemClick += delegate(object sender, AdapterView.ItemClickEventArgs e)
                    {
                        int x = 0;
                    };

                    settings = MenuHelper.CreateMenu(ApplicationContext);
                    settingsAdapter = new SettingsAdapter(ApplicationContext, Resource.Layout.activity_settings, settings);

                }
                catch (Exception ex)
                {
                    ex.ToString();
                }

                try
                {
                    View expandableHeaderReference = LayoutInflater.Inflate(Resource.Layout.activity_expandable_listview_header, null);
                    if (expandableHeaderReference != null)
                    {
                        mDrawerListLeft.AddHeaderView(expandableHeaderReference);

                        TextView tv_userName = expandableHeaderReference.FindViewById<TextView>(Resource.Id.current_customer_name);
                        if (tv_userName != null)
                        {
                            tv_userName.Text = "Firstname lastname";
                        }

                        TextView tv_location = expandableHeaderReference.FindViewById<TextView>(Resource.Id.current_customer_location);
                        if (tv_location != null)
                        {
                            tv_location.Text = "Timisoara, Romanaia";
                        }

                        //ImageView iv_profilePicture = (ImageView) expandableHeaderReference.findViewById(R.id.current_customer_image);
                        //if( iv_profilePicture != null)
                        //{
                        //    imageLoader.displayImage(currentUser.getPicture(), iv_profilePicture, ImageLoaderManager.getImageLoaderOptions(),new ImageLoadingListener() {
                        //        @Override
                        //        public void onLoadingCancelled(String arg0, View arg1) {
                        //        }

                        //        @Override
                        //        public void onLoadingComplete(String arg0, View arg1, Bitmap arg2) {
                        //        }

                        //        @Override
                        //        public void onLoadingFailed(String arg0, View arg1, FailReason arg2) {
                        //        }

                        //        @Override
                        //        public void onLoadingStarted(String arg0, View arg1) {
                        //        }
                        //    });
                        //}

                        expandableHeaderReference.Click += delegate(object sender, EventArgs args)
                        {
                            int x = 0;
                        };
                    }
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }

            try
            {
                mDrawerListLeft.SetAdapter(settingsAdapter);

                mDrawerListLeft.ItemClick += delegate(object sender, AdapterView.ItemClickEventArgs args)
                {
                    int x = 0;
                };


                //mDrawerListLeft.GroupClick += (sender, args) =>
                //{
                //    return true;
                //};

                mDrawerListLeft.SetOnChildClickListener(this);

                int count = settingsAdapter.GroupCount;
                for (int position = 0; position < count; position++)
                {
                    this.mDrawerListLeft.ExpandGroup(position);
                }

                ActionBar.SetDisplayShowTitleEnabled(false);
                ActionBar.SetDisplayHomeAsUpEnabled(true);
                ActionBar.SetHomeButtonEnabled(true);
                ActionBar.SetBackgroundDrawable(Resources.GetDrawable(Resource.Drawable.blue_bar));

                // ActionBarDrawerToggle ties together the the proper interactions
                // between the sliding drawer and the action bar app icon
                mDrawerToggle = new ActionBarDrawerToggle(
                    this, /* host Activity */
                    mDrawerLayout, /* DrawerLayout object */
                    Resource.Drawable.ic_drawer, /* nav drawer image to replace 'Up' caret */
                    Resource.String.drawer_open, /* "open drawer" description for accessibility */
                    Resource.String.drawer_close /* "close drawer" description for accessibility */
                    );

                //mDrawerToggle.OnDrawerClosed(View view)
                //{
                //    ActionBar.Title = mTitle;
                //    InvalidateOptionsMenu();
                //};

                //mDrawerToggle.OnDrawerOpened(View drawverView)
                //{
                //    ActionBar.Title = mDrawerTitle;
                //    InvalidateOptionsMenu();
                //}
                             
                // This would disable the home button from being the menu toggle and revert it to normal "back" behavior
                // mDrawerToggle.setDrawerIndicatorEnabled(false); 
                mDrawerLayout.SetDrawerListener(mDrawerToggle);

                sliderInitialized = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public bool OnChildClick(ExpandableListView parent, View clickedView, int groupPosition, int childPosition, long id)
        {
            switch ((int)id)
            {
                case 101:
                    break;
                default:
                    break;
            }
            return false;
        }

        protected abstract void SelectItem();
    }
}

