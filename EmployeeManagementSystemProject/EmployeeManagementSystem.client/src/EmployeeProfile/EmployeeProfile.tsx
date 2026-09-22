import { Box } from '@mui/material';
import { useParams } from 'react-router-dom';

export const EmployeeProfile = () => {

   const currentUID = useParams().uid;
   
   return (
      <Box
         height="100%"
         width="100%">
         "Hello employee:      ${currentUID}"
      </Box>
   )



}

export default EmployeeProfile;