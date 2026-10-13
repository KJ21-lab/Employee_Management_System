import { Box, Card } from '@mui/material';
import { useParams } from 'react-router-dom';
import { useGetEmployeeQuery } from '../Employees/routes';
import myImage from '../assets/myImage.jpeg';
import { Form, SimpleItem } from 'devextreme-react/form';
import DataGrid, { Editing, FilterRow } from 'devextreme-react/cjs/data-grid';
//import DataGrid, { Column, Editing, FilterRow, Lookup } from 'devextreme-react/data-grid';

export const EmployeeProfile = () => {
   const currentUID = useParams().uid;
   const { data: employee } = useGetEmployeeQuery(currentUID ?? "");

   console.log(employee)

   interface Employee {
      employeeUID: string;
      employeeID: string;
      name: string;
      jobTitle: string;
      hireDate: string;
   }

   const mockEmployees: Employee[] = [
      {
         employeeUID: "e101a89b-3c21-4f11-9a1d-84221a221001",
         employeeID: "1001",
         name: "John Doe",
         jobTitle: "Software Developer",
         hireDate: "2023-01-15T00:00:00"
      },
      {
         employeeUID: "f202b90c-4d32-5a22-0b2e-95332b332002",
         employeeID: "1002",
         name: "Jane Smith",
         jobTitle: "Solutions Architect",
         hireDate: "2022-06-20T00:00:00"
      },
      {
         employeeUID: "a303c01d-5e43-6b33-1c3f-06443c443003",
         employeeID: "1003",
         name: "Michael Johnson",
         jobTitle: "Database Administrator",
         hireDate: "2021-11-01T00:00:00"
      },
      {
         employeeUID: "b404d12e-6f54-7c44-2d4a-17554d554004",
         employeeID: "1004",
         name: "Emily Davis",
         jobTitle: "UI/UX Designer",
         hireDate: "2024-02-10T00:00:00"
      },
      {
         employeeUID: "c505e23f-7a65-8d55-3e5b-28665e665005",
         employeeID: "1005",
         name: "Robert Wilson",
         jobTitle: "DevOps Engineer",
         hireDate: "2020-08-05T00:00:00"
      }
   ];

   return (
      <Box
         height="100%"
         width="100%"
         //border="8px solid black"
         display="flex"
         justifyContent="space-between"
         alignItems="center">

         <Card
            elevation={10}
            sx={{
               height: "95%",
               width: "63%",
               transformOrigin: "bottom",
               borderRadius: '0 1.5vw  1.5vw 0',
            }}>
            <DataGrid
               dataSource={mockEmployees}
               showBorders
            >
            <FilterRow visible={true} />
            <Editing
               mode="row"
               allowUpdating
               allowDeleting
               allowAdding />
            </DataGrid>
         </Card>

         <Card
            elevation={10}
            sx={{
               height: "100%",
               width: "35%",
               borderRadius: '1.5vw 0 0 1.5vw',
               display: 'flex',
               gap: 5
            }}>
            <img
               src={myImage}
               width={200}
               height={200}
               style={{
                  borderRadius: '1.5vw',
                  marginLeft: 20,
                  marginTop: 30
               }} />
           
            <Form
               formData={employee}
               height="100%"
               width="100%"
               //disabled
               style={{
                  //border: "8px solid black",
               }}>
               <SimpleItem dataField="employeeID"/>
               <SimpleItem dataField="name" />
               <SimpleItem dataField="jobTitle" />
               <SimpleItem dataField="hireDate" editorType="dxDateBox" />
            </Form>
         </Card>
      </Box>
   )
}

export default EmployeeProfile;