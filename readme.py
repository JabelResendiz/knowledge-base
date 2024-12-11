import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
from scipy import stats
import seaborn as sns
import requests
from io import StringIO


# Load the data into a pandas DataFrame
df = pd.read_csv(r'c:\Users\HP\Downloads\Housing.csv')

# Convert 'price' to numeric, just in case
df['price'] = pd.to_numeric(df['price'], errors='coerce')

# Remove any NaN values
df = df.dropna(subset=['price'])

# Basic statistics
print("Basic Statistics:")
print(df['price'].describe())

# Normality Test (Shapiro-Wilk)
_, p_value_normal = stats.shapiro(df['price'])
print(f"\nShapiro-Wilk Test for Normality:")
print(f"p-value: {p_value_normal:.4f}")

# Exponential Distribution Test (Kolmogorov-Smirnov)
_, p_value_exp = stats.kstest(df['price'], 'expon')
print(f"\nKolmogorov-Smirnov Test for Exponential Distribution:")
print(f"p-value: {p_value_exp:.4f}")

# Poisson Distribution Test (Chi-Square Goodness of Fit)
observed, bins = np.histogram(df['price'], bins=30)
lambda_param = df['price'].mean()
expected = stats.poisson.pmf(bins[:-1], lambda_param) * len(df['price'])
chi2, p_value_poisson = stats.chisquare(observed, expected)
print(f"\nChi-Square Test for Poisson Distribution:")
print(f"p-value: {p_value_poisson:.4f}")

# Log-Normal Distribution Test
_, p_value_lognorm = stats.kstest(np.log(df['price']), 'norm')
print(f"\nKolmogorov-Smirnov Test for Log-Normal Distribution:")
print(f"p-value: {p_value_lognorm:.4f}")

# Visualizations
plt.figure(figsize=(20, 15))

# Histogram
plt.subplot(2, 2, 1)
sns.histplot(df['price'], kde=True)
plt.title('Histogram of House Prices')
plt.xlabel('Price')
plt.ylabel('Frequency')

# Q-Q plot for Normal Distribution
plt.subplot(2, 2, 2)
stats.probplot(df['price'], dist="norm", plot=plt)
plt.title('Q-Q Plot (Normal Distribution)')

# Q-Q plot for Exponential Distribution
plt.subplot(2, 2, 3)
stats.probplot(df['price'], dist="expon", plot=plt)
plt.title('Q-Q Plot (Exponential Distribution)')

# Q-Q plot for Log-Normal Distribution
plt.subplot(2, 2, 4)
stats.probplot(np.log(df['price']), dist="norm", plot=plt)
plt.title('Q-Q Plot (Log-Normal Distribution)')

plt.tight_layout()
plt.show()

# Calculate skewness and kurtosis
skewness = df['price'].skew()
kurtosis = df['price'].kurtosis()

print(f"\nSkewness: {skewness:.4f}")
print(f"Kurtosis: {kurtosis:.4f}")