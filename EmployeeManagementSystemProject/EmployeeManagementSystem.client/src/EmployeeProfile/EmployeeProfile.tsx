import { Box, Card } from '@mui/material';
import { useParams } from 'react-router-dom';
import { useGetEmployeeQuery } from '../Employees/routes';
//import DataGrid, { Column, Editing, FilterRow, Lookup } from 'devextreme-react/data-grid';

export const EmployeeProfile = () => {
   const currentUID = useParams().uid;
   const { data: employee = {} } = useGetEmployeeQuery(currentUID ?? "");

   console.log(employee)

   return (
      <Box
         height="100%"
         width="100%">
         <Card>

         </Card>

      </Box>
   )



}

export default EmployeeProfile;