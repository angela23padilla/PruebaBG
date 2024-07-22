import axios from 'axios';

const BASE_URL = 'http://localhost:7008'; // Replace with your API base URL

export const getProducts = async () => {
  try {
    const response = await axios.get(`${BASE_URL}/api/Producto/ConsultarProducto`);
    return response.data;
  } catch (error) {
    throw error;
  }
};

export const addProduct = async (productName) => {
  try {
    const response = await axios.post(`${BASE_URL}/api/Producto/GrabarProducto`, { 
      productoID: productName.productoID,
      usuarioID:1

     });
    return response.data; // Assuming your API returns the newly added product
  } catch (error) {
    throw error;
  }
};




export const updateProducts = async (products) => {
  try {
    console.log(products);
    const response = await axios.put(`${BASE_URL}/api/Producto/ModificarProducto`, {
      producto: products.producto,
      productoID: products.productoID
    });
    return response.data; // Assuming your API returns the updated product or success status
  } catch (error) {
    throw error;
  }
};


export const deleteProduct = async (productId) => {
  try {
    const response = await axios.delete(`${BASE_URL}/api/Producto/EliminarProducto`, {
      data: {
        productoID: productId.productoID
      }
    });
    console.log(response);
    return response.data; // Suponiendo que tu API devuelve el producto actualizado o un estado de éxito
  } catch (error) {
    throw error;
  }
};


export const getCartItems = async (usuarioID) => {
  try {
    const response = await axios.get(`${BASE_URL}/api/Producto/ConsultarProductoCarrito?usuarioID=${1}`);
    return response.data;
  } catch (error) {
    throw error;
  }
};
// Implementar las funciones para crear, actualizar y eliminar productos según tu API
