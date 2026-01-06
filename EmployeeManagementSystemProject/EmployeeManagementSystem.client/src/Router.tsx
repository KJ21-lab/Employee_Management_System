import {
  createBrowserRouter,
} from "react-router-dom";
import { Layout } from './Layout/InitialLayout';
import LoginPage from './Authenitication/Login';

const Loading: React.FC = () => <div>Loading...</div>;

export const router = createBrowserRouter([{
      path: "/",
      element: <Layout/>,
     /* errorElement: ,*/
      children: [
         // --- PUBLIC ROUTES ---
         {
            index: true,
            element: <LoginPage/>,
         },

         {
            //element: ,
            children: [
               {
                  path: 'home'
               }
            ]
         }

      ]
   }
]);