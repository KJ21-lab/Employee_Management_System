import { useCreateEmployeeMutation, useDeleteEmployeeMutation, useGetEmployeesQuery, useUpdateEmployeeMutation } from './routes';
//import { DataGrid, GridRowModes, ToolbarButton, type GridColDef, type GridRowModesModel, type GridRowsProp, type GridSlotProps, type GridSlots } from '@mui/x-data-grid';
import DataGrid, { Column, Editing, FilterRow, Lookup } from 'devextreme-react/data-grid';
import Box from '@mui/material/Box';
import './EmployeeIndex.scss'
import { useCallback } from 'react';
import type { Employee } from './types';
import notify from "devextreme/ui/notify";
import roles from './roles';
import { Link } from 'react-router-dom';
import type { ColumnCellTemplateData, RowInsertedEvent, RowRemovedEvent, RowUpdatedEvent } from 'devextreme/ui/data_grid_types';


export const EmployeeIndex = () => {

   const { data: employees = [] } = useGetEmployeesQuery();
   const [createEmployee]         = useCreateEmployeeMutation();
   const [updateEmployee] = useUpdateEmployeeMutation();
   const [deleteEmployee] = useDeleteEmployeeMutation();

   const employeeList = employees.map(emp => ({ ...emp }));

   console.log(employeeList)

   const handleCreatingEmployees = useCallback(async (e: RowInsertedEvent<Employee>) => {
      try {
         await createEmployee({
            employeeUID: "",
            employeeID: e.data.employeeID,
            name: e.data.name,
            jobTitle: e.data.jobTitle,
            hireDate: e.data.hireDate,
         }).unwrap();

         notify("Employee created succesfully.", "success", 3000)
      } catch (error) {
         console.log("Employee creation failed")
      }
   }, [createEmployee]);

   const handleUpdatingEmployees = useCallback(async (e: RowUpdatedEvent<Employee>) => {
      try {
         console.log(e.data.jobTitle)

         await updateEmployee({
            employeeUID: e.key ?? "",
            employeeID: e.data.employeeID,
            name: e.data.name,
            jobTitle: e.data.jobTitle,
            hireDate: e.data.hireDate,
         }).unwrap();

         notify("Employee updated succesfully.", "success", 3000)
      } catch (error) {
         console.log("Employee update failed")
      }
   }, [updateEmployee]);

   const handleDeleteEmployees = useCallback(async (e: RowRemovedEvent<Employee>) => {
      try {

         await deleteEmployee(e.key).unwrap();

         notify("Employee deleted succesfully.", "success", 3000)
      } catch (error) {
         console.log("Employee deletion failed")
      }
   }, [deleteEmployee]);

   const navigateToEmployee = (e: ColumnCellTemplateData) => {
      return <Link to={`/employee/${e.data?.employeeUID}`}>{e.value}</Link>;
   };

   return (
      <Box
         height="100%"
         width="100%"
         display="flex"
         justifyContent="flex-end"
         alignItems="flex-start"
         //border="8px solid black"
         alignSelf="flex-end">
         <DataGrid
            dataSource={employeeList}
            keyExpr="employeeUID"
            width="100%"
            showBorders
            onRowInserted={handleCreatingEmployees}
            onRowUpdated={handleUpdatingEmployees}
            onRowRemoved={handleDeleteEmployees}
            rowAlternationEnabled>
            <Column
               dataField="employeeID"
               caption="Employee ID"
               alignment="left"
               dataType="string"
               cellRender={navigateToEmployee}
            />
            <Column
               dataField="name"
               caption="Name"
               alignment="left"
               dataType="string"
            />
            <Column
               dataField="jobTitle"
               caption="Job Title"
               alignment="left"
               dataType="string">
               <Lookup dataSource={roles} displayExpr="Name" valueExpr="Name" />
            </Column>
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