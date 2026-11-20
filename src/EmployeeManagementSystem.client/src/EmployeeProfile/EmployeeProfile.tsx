import { Box, Card } from '@mui/material';
import { Button } from 'devextreme-react/button';
import DataGrid, { Editing, FilterRow } from 'devextreme-react/cjs/data-grid';
import { Form, SimpleItem } from 'devextreme-react/form';
import type { ILookupOptions } from 'devextreme-react/lookup';
import { useParams } from 'react-router-dom';
import { useGetEmployeeQuery } from '../Employees/routes';
import myImage from '../assets/myImage.jpeg';
import { positions } from './positions';
import './EmployeeProfile.css'
import { useState } from 'react';
//import DataGrid, { Column, Editing, FilterRow, Lookup } from 'devextreme-react/data-grid';

export const EmployeeProfile = () => {
   const currentUID = useParams().uid;
   const { data: employee } = useGetEmployeeQuery(currentUID ?? "");
   const [isEditing, setEditing] = useState<boolean>(true);

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

   const positionEditorOptions: ILookupOptions = {
      items: positions, searchEnabled: true
   };

   return (
      <Box
         height="100%"
         width="100%"
         //border="8px solid black"
         display="flex"
         justifyContent="space-between"
         alignItems="flex-end">

         {/* ==============
             DATA GRID CARD 
             ============== */}
         <Card
            elevation={10}
            className="data-grid-card"
            sx={{ borderRadius: "0 1.5vw  1.5vw 0" }}>
            <DataGrid
               dataSource={mockEmployees}
               showBorders>
            <FilterRow visible/>
            <Editing
               mode="row"
               allowUpdating
               allowDeleting
               allowAdding />
            </DataGrid>
         </Card>

         {/* ==============
              PROFILE CARD
             ============== */}
         <Card
            elevation={10}
            className="profile-card"
            sx={{
               gap: 2,
               borderRadius: "1.5vw 0 0 1.5vw"
            }}>

            <Box
               sx={{
                  display: 'flex',
                  justifyContent: 'flex-end'
               }}>
               <Button
                  width="20%"
                  text="Edit"
                  stylingMode="contained"
                  icon="edit"
                  style={{ marginTop: 5, marginRight: 5 }}
                  onClick={() => setEditing(!isEditing)}
                  />
            </Box>

            <Box
               className="profile-box"
               sx={{
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
                  disabled={isEditing}
                  style={{
                     //border: "8px solid black",
                     marginTop: 15
                  }}>
                  <SimpleItem dataField="employeeID" />
                  <SimpleItem dataField="name" />
                  <SimpleItem dataField="jobTitle" editorType="dxSelectBox" editorOptions={positionEditorOptions} />
                  <SimpleItem dataField="hireDate" editorType="dxDateBox" />
               </Form>
            </Box>
           
         </Card>
      </Box>
   )
}

export default EmployeeProfile;