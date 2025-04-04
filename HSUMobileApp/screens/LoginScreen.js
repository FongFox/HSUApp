import React from 'react';
import { View, Text, TextInput, TouchableOpacity, Image, StyleSheet } from 'react-native';
import { FontAwesome } from '@expo/vector-icons';

const LoginScreen = () => {
  return (
    <View style={styles.container}>
      <Image
        source={require('../assets/hsulogo.png')}
        style={styles.logo}
        resizeMode="contain"
      />

      <Text style={styles.title}>Đăng nhập</Text>

      <View style={styles.inputContainer}>
        <FontAwesome name="envelope" size={18} color="#888" style={styles.icon} />
        <TextInput
          placeholder="Email sinh viên"
          placeholderTextColor="#999"
          style={styles.input}
          keyboardType="email-address"
        />
      </View>

      <View style={styles.inputContainer}>
        <FontAwesome name="lock" size={18} color="#888" style={styles.icon} />
        <TextInput
          placeholder="Mật khẩu"
          placeholderTextColor="#999"
          style={styles.input}
          secureTextEntry
        />
      </View>

      <TouchableOpacity style={styles.button}>
        <Text style={styles.buttonText}>Đăng nhập</Text>
      </TouchableOpacity>
    </View>
  );
};

export default LoginScreen;

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    padding: 20,
    justifyContent: 'center',
    alignItems: 'center',
  },
  logo: {
    width: 160,
    height: 80,
    marginBottom: 30,
  },
  title: {
    fontSize: 24,
    marginBottom: 30,
    fontWeight: '600',
    color: '#0A4DA2',
  },
  inputContainer: {
    flexDirection: 'row',
    alignItems: 'center',
    width: '100%',
    backgroundColor: '#f1f1f1',
    borderRadius: 14,
    marginBottom: 15,
    paddingHorizontal: 10,
    shadowColor: '#000',
    shadowOpacity: 0.05,
    shadowOffset: { width: 0, height: 2 },
    shadowRadius: 4,
    elevation: 2,
  },
  icon: {
    marginRight: 8,
  },
  input: {
    flex: 1,
    paddingVertical: 15,
    fontSize: 16,
  },
  button: {
    backgroundColor: '#0A4DA2',
    padding: 15,
    width: '100%',
    borderRadius: 14,
    alignItems: 'center',
    marginTop: 10,
    shadowColor: '#000',
    shadowOpacity: 0.1,
    shadowOffset: { width: 0, height: 3 },
    shadowRadius: 4,
    elevation: 4,
  },
  buttonText: {
    color: '#fff',
    fontSize: 16,
    fontWeight: '500',
  },
});
