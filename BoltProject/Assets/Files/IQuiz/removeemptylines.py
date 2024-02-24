def remove_empty_lines(input_file, output_file):
    with open(input_file, 'r') as file:
        lines = file.readlines()

    # Remove empty lines
    non_empty_lines = [line for line in lines if line.strip()]

    with open(output_file, 'w') as file:
        file.writelines(non_empty_lines)

# Example usage:
input_file = 'generated.txt'
output_file = 'iquiz.txt'
remove_empty_lines(input_file, output_file)
