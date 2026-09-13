import { useCreateEmployeeMutation, useGetEmployeesQuery } from './routes';
//import { DataGrid, GridRowModes, ToolbarButton, type GridColDef, type GridRowModesModel, type GridRowsProp, type GridSlotProps, type GridSlots } from '@mui/x-data-grid';
import DataGrid, { Column, Editing, FilterRow } from 'devextreme-react/data-grid';
import Box from '@mui/material/Box';
import './EmployeeIndex.scss'
import { useCallback } from 'react';
import type { RowInsertedEvent } from 'devextreme/ui/data_grid';
import type { Employee } from './types';
import notify from 'devextreme/ui/notify';


export const EmployeeIndex = () => {

   const { data: employees = [] } = useGetEmployeesQuery();
   const [createEmployee] = useCreateEmployeeMutation();

   const epmloyeeList = [...employees]

   console.log(epmloyeeList)

   const handleCreatingEmployees = useCallback(async (e: RowInsertedEvent<Employee>) => {
      try {
         console.log(e.data)
         await createEmployee({
            employeeUID: "",
            employeeID: e.data.employeeID,
            name: e.data.name,
            jobTitle: e.data.jobTitle,
            hireDate: e.data.hireDate,
         }).unwrap();

         notify("Employee created succesfully.", "sucess", 3000)
      } catch (error) {
         console.log("Employee creation failed")
      }
   }, [createEmployee]);


   return (
      <Box height="100vh" width="85vw" justifyContent="flex-end" alignItems="center"border="8px solid black" alignSelf="flex-end">
         <DataGrid
            dataSource={epmloyeeList}
            keyExpr="employeeUID"
            width="100%"
            showBorders
            onRowInserted={handleCreatingEmployees}
            rowAlternationEnabled>
            <Column
               dataField="employeeID"
               caption="Employee ID"
               alignment="left"
            />
            <Column
               dataField="name"
               caption="Name"
               alignment="left"
            />
            <Column
               dataField="jobTitle"
               caption="Job Title"
               alignment="left"
            />
            <Column
               dataField="hireDate"
               caption="Hire Date"
               alignment="left"
               dataType="date"
            />
            <FilterRow visible={true} />
            <Editing
               mode="row"
               allowUpdating
               allowDeleting
               allowAdding/>
         </DataGrid>
      </Box>
   );
}

export default EmployeeIndex; 