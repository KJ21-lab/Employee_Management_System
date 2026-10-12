import { Box, Card } from '@mui/material';
import { useParams } from 'react-router-dom';
import { useGetEmployeeQuery } from '../Employees/routes';
import myImage from '../assets/myImage.jpeg';
//import DataGrid, { Column, Editing, FilterRow, Lookup } from 'devextreme-react/data-grid';

export const EmployeeProfile = () => {
   const currentUID = useParams().uid;
   const { data: employee } = useGetEmployeeQuery(currentUID ?? "");

   console.log(employee)

   return (
      <Box
         height="100%"
         width="100%"
         //border="8px solid black"
         display="flex"
         justifyContent="flex-end">
         <Card
            elevation={10}
            sx={{
               height: "100%",
               width: "500px",
               borderRadius: '1.5vw 0 0 1.5vw ',
               display: 'flex',
               justifyContent: "center"
            }}>
            <img
               src={myImage}
               width={300}
               height={300}
               style={{
                     borderRadius: '1.5vw'
                  }}
               />
         </Card>

      </Box>
   )
}

export default EmployeeProfile;