import axios from 'axios';

const BASE_URL = 'http://localhost:7008'; // Reemplaza con la URL de tu backend

// Función para autenticar al usuario
export const authenticate = async (user, password) => {
  try {
    const response = await axios.post(`${BASE_URL}/api/Usuario/Validar`, {
        usuario:user,
        contraseña:password,
    });
    return response.data; // Deberías recibir un token de autenticación u otra respuesta del backend
  } catch (error) {
    throw error; // Maneja errores de manera adecuada en tu aplicación
  }
};