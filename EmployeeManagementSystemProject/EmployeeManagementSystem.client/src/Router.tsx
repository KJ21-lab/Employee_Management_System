import { createBrowserRouter } from "react-router-dom";
import { Layout } from './Layout/InitialLayout';
import LoginPage from './Authenitication/Login';
import HomePage from './Home/HomePage';
import RequiredAuth from './Authenitication/RequiredAuth';
import EmployeeIndex from './Employees/EmployeeIndex';

export const router = createBrowserRouter([
   {
      path: "/",
      // The Login page should usually have its own simple layout or no layout at all
      element: <LoginPage />,
   },
   {
      path: "/",
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
               }
            ]
         }
      ]
   }
]);