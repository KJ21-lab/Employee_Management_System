import { Box, CssBaseline, Stack } from '@mui/material'

export const Layout = () => {
   return (
      <div style={{display: 'flex'}}>
         <CssBaseline>
            {/*<Box*/}
            {/*   sx={{*/}
            {/*      width: '100vw',*/}
            {/*      height: '100vh',*/}
            {/*      borderRadius: '5px 5px 5px 5px',*/}
            {/*      bgcolor: '#f0f0f0',*/}
            {/*      flexDirection: 'row'*/}
            {/*   }}>*/}
            {/*</Box>*/}
            {/*<Box*/}
            {/*   sx={{*/}
            {/*      width: '30vh',*/}
            {/*      height: '100%',*/}
            {/*      borderRadius: '5px 0 0 4px',*/}
            {/*      bgcolor: '#000033',*/}
            {/*      flexDirection: 'row'*/}
            {/*   }}>*/}
            {/*</Box>*/}
            <Stack direction="row" spacing={0}>

               <Box
                  sx={{
                     width: '15vw',
                     height: '100vh',
                     borderRadius: '5px 0 0 4px',
                     bgcolor: '#000033'
                  }} />
               <Box sx={{
                  mt: 8,
                  width: '100vw',
                  height: '100vh',
                  borderRadius: '5px 5px 5px 5px',
                  bgcolor: '#f0f0f0'
               }} />

            </Stack>
         </CssBaseline>
      </div>

   )
}