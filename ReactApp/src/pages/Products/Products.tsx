import React, { ReactElement, FC } from "react";
import { Box, Typography } from "@mui/material";

const Products: FC<unknown> = (): ReactElement => {
  return (
    <Box
      sx={{
        flexGrow: 1,
        backgroundColor: "whitesmoke",
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
      }}
    >
      <Typography variant="h3">Products</Typography>
    </Box>
  );
};

export default Products;