import { Navigation } from 'models/navigation';

export class SidebarNavigation {
  navigationList: Navigation[];

  constructor() {
    this.navigationList = [
      {
        type: "item",
        name: "Dashboard",
        url: "/",
        icon: "fa fa-tachometer",
      },
      {
        type: "divider",
        name: "divider"
      },
      {
        type: "dropdown",
        name: "Calendar",
        icon: "fa fa-calendar-o",
        children: [
          {
            type: "item",
            name: "View Calendar",
            url: "/calendar",
            icon: "fa fa-calendar",
          }
        ]
      },
      {
        type: "dropdown",
        name: "Instructors",
        icon: "fa fa-address-book-o",
        children: [
          {
            type: "item",
            name: "View Instructors",
            url: "/instructors",
            icon: "fa fa-address-card-o",
          },
          {
            type: "divider",
            name: "divider"
          },
          {
            type: "item",
            name: "Create Instructor",
            url: "/instructor/create",
            icon: "fa fa-address-card-o",
          },

        ]
      },
      {
        type: "dropdown",
        name: "Administrative",
        icon: "fa fa-cogs",
        children: [
          {
            type: "item",
            name: "Locations",
            url: "/locations",
            icon: "fa fa-map-marker",
          },
          {
            type: "item",
            name: "Groups",
            url: "/groups",
            icon: "fa fa-users",
          },
          {
            type: "divider",
            name: "divider"
          },
          {
            type: "item",
            name: "Manage Users",
            url: "/organization/membership",
            icon: "fa fa-user",
          },
          {
            type: "item",
            name: "Organization Settings",
            url: "/organization/settings",
            icon: "fa fa-cog",
          },
        ]
      },
      {
        type: "dropdown",
        name: "User",
        icon: "fa fa-user",
        children: [
          {
            type: "item",
            name: "Edit Profile",
            url: "/user/profile",
            icon: "fa fa-user-circle-o",
          }
        ]
      },
    ]
  }
}
