import { createBrowserRouter } from "react-router-dom";
import { Layout } from './Layout/InitialLayout';
import LoginPage from './Authenitication/Login';
import HomePage from './Home/HomePage';
import RequiredAuth from './Authenitication/RequiredAuth';
import EmployeeIndex from './Employees/EmployeeIndex';
import { EmployeeProfile } from './EmployeeProfile/EmployeeProfile';



export const router = createBrowserRouter([
   {
      path: "/",
      element: <LoginPage />,
   },
   {
      element: <RequiredAuth />,
      children: [
         {
            element: <Layout />, children: [
               {
                  path: 'home',
                  element: <HomePage />
               },
               {
                  path: 'employees',
                  element: <EmployeeIndex />
               },
               {
                  //path: `${}`,
                  element: <EmployeeProfile />
               }
            ]
         }
      ]
   }
]);