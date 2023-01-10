
# Simple Phonebook Application

> 2022 Summer Internship Project

A Simple Phonebook Application that uses ASPNET.CORE MVC. In this Phonebook application, you can create, update, and remove contacts and their phone numbers.

There are two classes: ``Contact`` and ``PhoneNumber``. There are **one-to-many** relationship between ``Contact`` and ``PhoneNumber``. The following image shows this relationship and fields.

![Relationship](img/Contact_and_PhoneNumber_Relationship.png)

> In ``Contact`` class, *all fields are optional except **FirstName** and **LastName***

## Libraries Used

**AutoMapper** used to convert ViewModels to Models

**FluentValidation** used to validation processes

**Autofac** used to dependency injection

## Pages

#### Contact Home Page

![Contact_Home_Page](img/contact_home_page.png)

#### Contact Create Page

![Contact_Create_Page](img/contact_create_page.png)

#### Contact Edit Page

![Contact_Edit_Page](img/contact_edit_page.png)

#### Contact Search Page

![Contact_Search_Page](img/contact_search_page.png)

#### Contact Details Page

![Contact_Details_Page](img/contact_details_page.png)

#### Contact Phone Numbers Page

![Contact_Phone_Numbers_Page](img/contact_phoneNumbers_page.png)

#### Phone Number Home Page

![PhoneNumber_Home_Page](img/phoneNumber_home_page.png)

#### Phone Number Create Page

![PhoneNumber_Create_Page](img/phoneNumber_create_page.png)

#### Phone Number Edit Page

![PhoneNumber_Create_Page](img/phoneNumber_edit_page.png)
