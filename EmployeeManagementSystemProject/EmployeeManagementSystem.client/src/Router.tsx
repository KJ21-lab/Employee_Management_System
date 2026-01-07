import { createBrowserRouter } from "react-router-dom";
import { Layout } from './Layout/InitialLayout';
import LoginPage from './Authenitication/Login';
import HomePage from './Home/HomePage';
import RequiredAuth from './Authenitication/RequiredAuth';

export const router = createBrowserRouter([{
   path: "/",
   element: <Layout />,
   /* errorElement: ,*/
   children: [
      // --- PUBLIC ROUTES ---
      {
         index: true,
         element: <LoginPage />,
      },

      {
         element: <RequiredAuth />,
         children: [
            {
               path: '/home',
               element: <HomePage />
            }
         ]
      }

   ]
}
]);