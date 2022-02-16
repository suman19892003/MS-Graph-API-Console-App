# MSGraphAPI-Console-App
This application is written in C# Console application that performs below task
1. Generates token and return to MS Graph api
2. MS Graph api retrieves document and metadata from SharePoint library using App Registration.

# Result from Console
![image](https://user-images.githubusercontent.com/45258794/154326832-64b706e3-f2f7-490e-8896-85543eb7d1af.png)

# Steps for Regsitering App
1. Navigate to App Registration in Azure Active Directory > New Registration > Provide Name(TestGraphAPI)
2. Select "Accounts in any organizational directory (Any Azure AD directory - Multitenant)" > Provide other details as below
![image](https://user-images.githubusercontent.com/45258794/154327629-f8b7007f-9a71-4e4f-9200-26d323d07a68.png)
3. Click API Permission > Add a permission > Select SharePoint > Permission Type Delegated
![image](https://user-images.githubusercontent.com/45258794/154328372-57dbf970-051b-44db-b31d-9f31af18b3c8.png)
4. Click Authentication > Add a Platform > Select Mobile and Desktop Application > Add URL as "https://localhost"
![image](https://user-images.githubusercontent.com/45258794/154328870-345671aa-0dec-4e90-8a83-79f44006a1cd.png)



